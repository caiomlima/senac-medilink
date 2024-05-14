using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Entity
{
    public class ProfessionalSpecialty
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
            Professionals = new List<Professional>();
        }

        public string Name { get; private set; }
        public string Description { get; private set; } // opcional
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public virtual ICollection<Professional> Professionals { get; private set; }

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
