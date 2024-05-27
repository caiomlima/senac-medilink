using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;

namespace Senac.Medilink.Services.Interface
{
    public interface IScheduleService
    {
        Task AddScheduleAsync(ScheduleRequest request, CancellationToken cancellationToken = default);
        Task<List<FreeScheduleSlotResult>> GetAvailableSlotsForScheduling(long professionalId, DateTime startDate, int durationInMinutes = 20, CancellationToken cancellationToken = default);
    }
}
