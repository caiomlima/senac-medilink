using Microsoft.EntityFrameworkCore;
using Senac.Medilink.Common;
using Senac.Medilink.Data;
using Senac.Medilink.Data.Dto.Request;
using Senac.Medilink.Data.Dto.Result;
using Senac.Medilink.Data.Entity;
using Senac.Medilink.Services.Interface;

namespace Senac.Medilink.Services;

public class ProfessionalService : IProfessionalService
{
    private readonly DatabaseContext _databaseContext;
    private readonly IScheduleService _scheduleService;

    public ProfessionalService(DatabaseContext databaseContext, IScheduleService scheduleService)
    {
        _databaseContext = databaseContext;
        _scheduleService = scheduleService;
    }

    // Method horroroso ...
    public async Task<IEnumerable<ProfessionalsForSchedulingResult>> GetForSchedulingAsync(ProfessionalsForSchedulingRequest request, CancellationToken cancellationToken = default)
    {
        var professionalsQuery = _databaseContext.ProfessionalSpecialties
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Include(ps => ps.Professional)
            .Where(ps => ps.Active && ps.Professional.Active);

        if (request.FormOfService == FormOfService.Presential)
            professionalsQuery = professionalsQuery.Where(ps => ps.UnitId == request.UnitId && ps.SpecialtyId == request.SpecialtyId);
        else
            professionalsQuery = professionalsQuery.Where(ps => ps.SpecialtyId == request.SpecialtyId);

        var professionalsIds = await professionalsQuery
            .Select(ps => ps.ProfessionalId)
            .ToListAsync(cancellationToken);

        return await _databaseContext.Professionals
            .AsNoTracking()
            .IgnoreAutoIncludes()
            .Where(p => professionalsIds.Contains(p.Id))
            .Select(p => (ProfessionalsForSchedulingResult)p)
            .ToListAsync(cancellationToken);
    }
}
