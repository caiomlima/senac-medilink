using Senac.Medilink.Data.Entity.Common;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Entity
{
    public class ProfessionalSpecialty : BaseEntity
    {
        public ProfessionalSpecialty() { }

        public ProfessionalSpecialty(
            long specialtyId,
            long professionalId,
            long unitId)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
            SpecialtyId = specialtyId;
            ProfessionalId = professionalId;
            UnitId = unitId;
        }

        public long SpecialtyId { get; private set; }
        public long ProfessionalId { get; private set; }
        public long UnitId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public virtual Specialty Specialty { get; private set; }
        public virtual Professional Professional { get; private set; }
        public virtual Unit Unit { get; private set; }

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
