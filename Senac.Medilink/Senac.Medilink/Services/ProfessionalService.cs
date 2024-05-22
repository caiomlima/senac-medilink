using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services
{
    public class ProfessionalService : IProfessionalService
    {
        private readonly DatabaseContext _databaseContext;

        public ProfessionalService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<ProfessionalResult>> GetAsync(long specialtyId, long? unitId, CancellationToken cancellationToken = default)
        {
            var professionalsIds = await _databaseContext.ProfessionalSpecialties
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .Include(ps => ps.Professional)
                .Where(ps => ps.SpecialtyId == specialtyId && ps.UnitId == unitId && ps.Active && ps.Professional.Active)
                .Select(ps => ps.ProfessionalId)
                .ToListAsync(cancellationToken);

            return await _databaseContext.Professionals
                .AsNoTracking()
                .IgnoreAutoIncludes()
                .Where(p => professionalsIds.Contains(p.Id))
                .Select(p => (ProfessionalResult)p)
                .ToListAsync(cancellationToken);
        }
    }
}
