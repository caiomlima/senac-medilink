using Senac.Medilink.Data.Entity.Common;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Entity
{
    public class ProfessionalSpecialty : BaseEntity
    {
        public ProfessionalSpecialty() { }

        public ProfessionalSpecialty(
            string name,
            string description)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
        }

        public long ProfessionalId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public virtual Professional Professional { get; private set; }
        public virtual Unit Unit { get; private set; }

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
