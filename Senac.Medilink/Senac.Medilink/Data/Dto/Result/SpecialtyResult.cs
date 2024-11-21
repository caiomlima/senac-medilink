using Senac.Medilink.Data.Entity;

namespace Senac.Medilink.Data.Dto.Result;

public class SpecialtyResult
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public static explicit operator SpecialtyResult(Specialty entity)
    {
        if (entity == null)
            return null;

        return new SpecialtyResult
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
        };
    }
}
