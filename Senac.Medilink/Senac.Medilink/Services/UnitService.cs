using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services
{
    public class UnitService : IUnitService
    {
        private readonly DatabaseContext _databaseContext;

        public UnitService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<UnitResult>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _databaseContext.Units
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .Select(s => (UnitResult)s)
                .ToListAsync(cancellationToken);
        }
    }
}
