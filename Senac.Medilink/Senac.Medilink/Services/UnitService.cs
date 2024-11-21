using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services;

public class UnitService : IUnitService
{
    private readonly DatabaseContext _databaseContext;

    public UnitService(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<IEnumerable<UnitResult>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _databaseContext.Unities
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Select(s => (UnitResult)s)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<UnitResult>> GetForSchedulingExamAsync(long specialtyId, CancellationToken cancellationToken = default)
    {
        var unities = await _databaseContext.ExamSpecialties
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Include(es => es.Unit)
            .Where(es => es.Active && es.Unit.Active)
            .Select(es => es.UnitId)
            .ToListAsync(cancellationToken);

        return await _databaseContext.Unities
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Where(p => unities.Contains(p.Id))
            .Select(p => (UnitResult)p)
            .ToListAsync(cancellationToken);
    }
}
