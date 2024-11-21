using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Data.Entity;

public class ExamSpecialty : BaseEntity
{
    public ExamSpecialty() {}

    public ExamSpecialty(
        long specialtyId,
        long unitId,
        DateTime createdAt,
        DateTime updatedAt,
        bool active)
    {
        SpecialtyId = specialtyId;
        UnitId = unitId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Active = active;
    }

    public long SpecialtyId { get; private set; }
    public long UnitId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public bool Active { get; private set; }

    public virtual Specialty Specialty { get; private set; }
    public virtual Unit Unit { get; private set; }

    internal void Inactivate()
    {
        Active = false;
        UpdatedAt = DateTime.Now;
    }
}
