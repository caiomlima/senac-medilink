using Senac.Medilink.Data.Dto.Request;

namespace Senac.Medilink.Services.Interface
{
    public interface IScheduleService
    {
        Task AddScheduleAsync(ScheduleRequest request, CancellationToken cancellationToken = default);
    }
}
