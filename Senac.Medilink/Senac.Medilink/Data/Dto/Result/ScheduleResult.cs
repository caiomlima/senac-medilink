using Senac.Medilink.Common;
using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.Dto.Result
{
    public class ScheduleResult
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public string ProfessionalName { get; set; }
        public string UnitName { get; set; }
        public string UnitDescription { get; set; }
        public string SpecialtyName { get; set; }
        public ServiceType Type { get; private set; }
        public FormOfService Form { get; private set; }
        public ScheduleStatus Status { get; private set; }

        public static explicit operator ScheduleResult(Schedule entity)
        {
            if (entity == null)
                return null;

            return new ScheduleResult
            {
                Id = entity.Id,
                Date = entity.StartDate,
                Duration = $"{entity.EndDate.Hour - entity.StartDate.Hour} mins.",
                ProfessionalName = entity.Professional?.Name,
                UnitName = entity.Unit?.Name ?? null,
                UnitDescription = entity.Unit?.Description ?? null,
                SpecialtyName = entity.Specialty?.Name,
                Type = entity.Type,
                Form = entity.Form,
                Status = entity.Status,
            };
        }
    }
}
