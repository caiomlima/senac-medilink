using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.Dto.Result
{
    public class UnitResult
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static explicit operator UnitResult(Unit entity)
        {
            if (entity == null)
                return null;

            return new UnitResult
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }
    }
}
