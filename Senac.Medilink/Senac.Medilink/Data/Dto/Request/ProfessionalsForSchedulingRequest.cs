using Senac.Medilink.Common;

namespace Senac.Medilink.Data.Dto.Request;

public class ProfessionalsForSchedulingRequest
{
    public long SpecialtyId { get; set; }
    public long? UnitId { get; set; }
    public FormOfService FormOfService { get; set; }
}
