using Senac.Medilink.Data.Dto.Result;

namespace Senac.Medilink.Services.Interface;

public interface IUnitService
{
    Task<IEnumerable<UnitResult>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<UnitResult>> GetForSchedulingExamAsync(long specialtyId, CancellationToken cancellationToken = default);
}
