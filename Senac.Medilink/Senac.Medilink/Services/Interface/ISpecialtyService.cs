using Senac.Medilink.Common;
using Senac.Medilink.Data.Dto.Result;

namespace Senac.Medilink.Services.Interface
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<SpecialtyResult>> GetAllAsync(ServiceType serviceType, CancellationToken cancellationToken = default);
    }
}
