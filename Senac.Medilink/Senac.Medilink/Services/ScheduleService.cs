using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Common;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;
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

        public Task AddScheduleAsync(ScheduleRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<FreeScheduleSlotResult>> GetAvailableSlotsForScheduling(long professionalId, DateTime startDate, int durationInMinutes = 20, CancellationToken cancellationToken = default)
        {
            var availableSlots = new List<FreeScheduleSlotResult>();
            var endDate = startDate.AddDays(7).Date; // range fixo de 7 dias ...

            var professionalSchedules = await _databaseContext.Schedules
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Where(x => x.ProfessionalId == professionalId && x.Status != ScheduleStatus.Canceled && x.StartDate <= endDate && x.EndDate >= startDate.Date)
                .ToListAsync(cancellationToken);

            var workSchedules = await _databaseContext.ProfessionalWorkSchedules
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .IgnoreQueryFilters()
                .Where(ws => ws.ProfessionalId == professionalId)
                .ToListAsync(cancellationToken);

            var actualDay = startDate.Date;
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

                foreach (var workSchedule in workSchedules)
                {
                    var currentTime = workSchedule.StartTime;
                    while (currentTime + TimeSpan.FromMinutes(durationInMinutes) <= workSchedule.EndTime)
                    {
                        var slotStart = actualDay.Add(currentTime);
                        var slotEnd = slotStart.AddMinutes(durationInMinutes);

                        var isSlotFree = !professionalSchedules.Any(s => s.StartDate < slotEnd && s.EndDate > slotStart);
                        if (isSlotFree)
                        {
                            availableSlots.Add(new FreeScheduleSlotResult
                            {
                                Day = actualDay,
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
    }
}
