using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;

namespace Senac.Medilink.Services.Interface;

public interface IScheduleService
{
    Task<IEnumerable<ScheduleResult>> GetSchedulesOfPatientAsync(long patientId, CancellationToken cancellationToken = default);
    Task AddAsync(ScheduleRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(long scheduleId, CancellationToken cancellationToken = default);
    Task<IEnumerable<FreeWorkScheduleSlotResult>> GetAvailableSlotsOfProfessionalForSchedulingAsync(long professionalId, long? unitId, DateTime startDate, int durationInMinutes = 30, CancellationToken cancellationToken = default);
    Task<IEnumerable<FreeWorkScheduleSlotResult>> GetAvailableSlotsOfUnitForSchedulingExamAsync(long unitId, long specialtyId, DateTime startDate, int durationInMinutes = 60, CancellationToken cancellationToken = default);
}
