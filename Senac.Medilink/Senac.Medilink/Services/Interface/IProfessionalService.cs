using Senac.Medilink.Data.Dto.Result;

namespace Senac.Medilink.Services.Interface
{
    public interface IProfessionalService
    {
        Task<IEnumerable<ProfessionalResult>> GetAsync(long specialtyId, long? unitId, CancellationToken cancellationToken = default);
    }
}
