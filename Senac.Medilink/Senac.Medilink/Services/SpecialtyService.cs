using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Senac.Medilink.Common;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly DatabaseContext _databaseContext;

        public SpecialtyService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<SpecialtyResult>> GetAllAsync(ServiceType serviceType, CancellationToken cancellationToken = default)
        {
            return await _databaseContext.Specialties
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .Where(s => s.Active && s.Type == serviceType)
                .Select(s => (SpecialtyResult)s)
                .ToListAsync(cancellationToken);
        }
    }
}
