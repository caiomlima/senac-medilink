using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;

namespace Senac.Medilink.Services.Interface
{
    public interface IProfessionalService
    {
        Task<IEnumerable<ProfessionalsForSchedulingResult>> GetForSchedulingAsync(ProfessionalsForSchedulingRequest request, CancellationToken cancellationToken = default);
    }
}
