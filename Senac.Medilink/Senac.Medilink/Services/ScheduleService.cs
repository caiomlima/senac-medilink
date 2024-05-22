using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Request;
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
    }
}
