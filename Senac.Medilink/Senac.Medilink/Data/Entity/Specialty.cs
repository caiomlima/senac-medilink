using Senac.Medilink.Data.Entity.Common;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Entity
{
    public class Specialty : BaseEntity
    {
        public Specialty() { }

        public Specialty(
            string name,
            string description)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
            Professionals = new List<Professional>();
            //ProfessionalSpecialties = new List<ProfessionalSpecialty>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; } // opcional
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public virtual ICollection<Professional> Professionals { get; private set; }
        //public virtual ICollection<ProfessionalSpecialty> ProfessionalSpecialties { get; private set; }

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
