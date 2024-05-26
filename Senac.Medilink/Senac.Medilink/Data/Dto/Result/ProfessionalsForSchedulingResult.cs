using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Dto.Result
{
    public class ProfessionalsForSchedulingResult
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static explicit operator ProfessionalsForSchedulingResult(Professional entity)
        {
            if (entity == null)
                return null;

            return new ProfessionalsForSchedulingResult
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }

    public class FreeScheduleSlotResult
    {
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
