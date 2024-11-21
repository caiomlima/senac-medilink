using Senac.Medilink.Common;

namespace Senac.Medilink.Data.Dto.Request;

public class ScheduleRequest
{
    public long? SpecialtyId { get; set; }
    public long? UnitId { get; set; }
    public long? ProfessionalId { get; set; }
    public long PatientId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public FormOfService FormOfService { get; set; }
    public ServiceType ServiceType { get; set; }
}
