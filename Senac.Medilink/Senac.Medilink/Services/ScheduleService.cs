using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Common;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Data.Entity;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly DatabaseContext _databaseContext;

        public ScheduleService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<ScheduleResult>> GetSchedulesOfPatientAsync(long patientId, CancellationToken cancellationToken = default)
        {
            return await _databaseContext.Schedules
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Include(s => s.Professional)
                .Include(s => s.Specialty)
                .Include(s => s.Unit)
                .Where(s => s.PatientId == patientId && s.Active)
                .OrderByDescending(s => s.StartDate)
                .Select(s => (ScheduleResult)s)
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(ScheduleRequest request, CancellationToken cancellationToken = default)
        {
            var schedule = new Schedule(
                request.PatientId,
                request.ProfessionalId,
                request.SpecialtyId,
                request.UnitId,
                request.StartDate,
                request.ServiceType == ServiceType.Appointment ? request.StartDate.AddMinutes(30) : request.StartDate.AddMinutes(60), // Duração fixa em 30 min para agendamentos comuns e 60 para exames
                request.FormOfService,
                request.ServiceType);

            _databaseContext.Add(schedule);
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(long scheduleId, CancellationToken cancellationToken = default)
        {
            var schedule = await _databaseContext.Schedules
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Where(s => s.Id == scheduleId && s.Active)
                .FirstOrDefaultAsync(cancellationToken);

            if (schedule == null)
                throw new Exception("Item não encontrado");

            schedule.Inactivate();
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<FreeWorkScheduleSlotResult>> GetAvailableSlotsOfProfessionalForSchedulingAsync(long professionalId, long? unitId, DateTime startDate, int durationInMinutes = 30, CancellationToken cancellationToken = default)
        {
            var availableSlots = new List<FreeWorkScheduleSlotResult>();
            var endDate = startDate.AddDays(15).Date; // range fixo 15 dias 

            var professionalSchedules = await _databaseContext.Schedules
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Where(x => x.ProfessionalId == professionalId 
                    && x.Status != ScheduleStatus.Canceled 
                    && x.StartDate <= endDate 
                    && x.EndDate >= startDate.Date)
                .ToListAsync(cancellationToken);

            var workSchedulesQuery = _databaseContext.ProfessionalWorkSchedules
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Where(ws => ws.ProfessionalId == professionalId);

            if (unitId != null)
                workSchedulesQuery = workSchedulesQuery.Where(x => x.UnitId == unitId);

            var workSchedules = await workSchedulesQuery.ToListAsync(cancellationToken);

            var actualDay = startDate.AddDays(1).Date; // começa mostrando apenas os de amanhã
            while (actualDay <= endDate)
            {
                var todayWorkSchedules = workSchedules
                    .Where(x => x.DayOfWeek == actualDay.DayOfWeek)
                    .OrderBy(x => x.StartTime);

                if (!todayWorkSchedules.Any())
                {
                    actualDay = actualDay.AddDays(1);
                    continue;
                }

                foreach (var workSchedule in todayWorkSchedules)
                {
                    var currentTime = workSchedule.StartTime;

                    while (currentTime + TimeSpan.FromMinutes(durationInMinutes) <= workSchedule.EndTime)
                    {
                        var slotStart = actualDay.Add(currentTime);
                        var slotEnd = slotStart.AddMinutes(durationInMinutes);

                        var isSlotFree = !professionalSchedules.Any(s => s.StartDate < slotEnd && s.EndDate > slotStart);
                        if (isSlotFree)
                        {
                            availableSlots.Add(new FreeWorkScheduleSlotResult
                            {
                                Day = new DateOnly(actualDay.Year, actualDay.Month, actualDay.Day),
                                StartTime = currentTime,
                                EndTime = currentTime + TimeSpan.FromMinutes(durationInMinutes)
                            });
                        }

                        currentTime = currentTime.Add(TimeSpan.FromMinutes(durationInMinutes));
                    }
                }

                actualDay = actualDay.AddDays(1);
            }

            availableSlots = availableSlots.OrderBy(x => x.Day).ToList();

            return availableSlots;
        }

        public async Task<IEnumerable<FreeWorkScheduleSlotResult>> GetAvailableSlotsOfUnitForSchedulingExamAsync(long unitId, long specialtyId, DateTime startDate, int durationInMinutes = 60, CancellationToken cancellationToken = default)
        {
            var availableSlots = new List<FreeWorkScheduleSlotResult>();
            var endDate = startDate.AddDays(10).Date; // range fixo 10 dias

            var existingExamSchedules = await _databaseContext.Schedules
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Where(x => x.UnitId == unitId
                    && x.Status != ScheduleStatus.Canceled 
                    && x.StartDate <= endDate 
                    && x.EndDate >= startDate.Date
                    && x.Type == ServiceType.Exam
                    && x.SpecialtyId == specialtyId)
                .ToListAsync(cancellationToken);

            var actualDay = startDate.AddDays(1).Date; // começa mostrando apenas os de amanhã
            while (actualDay <= endDate)
            {
                var currentTime = new TimeSpan(8,0,0); // começa as 08:00
                var endTime = new TimeSpan(18,0,0);

                while (currentTime + TimeSpan.FromMinutes(durationInMinutes) <= endTime)
                {
                    var slotStart = actualDay.Add(currentTime);
                    var slotEnd = slotStart.AddMinutes(durationInMinutes);

                    var isSlotFree = !(existingExamSchedules?.Where(s => s.StartDate < slotEnd && s.EndDate > slotStart)?.Count() > 2); // testes HAHAHAHAHAHAHAHA
                    if (isSlotFree)
                    {
                        availableSlots.Add(new FreeWorkScheduleSlotResult
                        {
                            Day = new DateOnly(actualDay.Year, actualDay.Month, actualDay.Day),
                            StartTime = currentTime,
                            EndTime = currentTime + TimeSpan.FromMinutes(durationInMinutes)
                        });
                    }

                    currentTime = currentTime.Add(TimeSpan.FromMinutes(durationInMinutes));
                }

                actualDay = actualDay.AddDays(1);
            }

            availableSlots = availableSlots.OrderBy(x => x.Day).ToList();

            return availableSlots;
        }
    }
}
