using Senac.Medilink.Common;

namespace Senac.Medilink.Data.Dto.Result
{
    public class ScheduleSummary
    {
        public FormOfService FormOfService { get; set; }
        public ServiceType Type { get; set; }
        public long? SpecialtyId { get; set; }
        public string SpecialtyName { get; set; }
        public long? ProfessionalId { get; set; }
        public string ProfessionalName { get; set; }
        public DateTime Date { get; set; }
        public long? UnitId { get; set; }
        public string UnitName { get; set; }
        public string UnitDescription { get; set; }
    }
}
