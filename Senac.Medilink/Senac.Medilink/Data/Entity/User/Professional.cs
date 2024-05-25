using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Data.Entity.User
{
    public class Professional : BaseEntity
    {
        public Professional() { }

        public Professional(string name, string document)
        {
            Name = name;
            Document = document;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Active = true;
            WorkSchedules = new List<ProfessionalWorkSchedules>();
            Schedules = new List<Schedule>();
            ProfessionalSpecialties = new List<ProfessionalSpecialty>();
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public virtual User User { get; private set; }
        public virtual ICollection<ProfessionalWorkSchedules> WorkSchedules { get; private set; }
        public virtual ICollection<Schedule> Schedules { get; private set; }
        public virtual ICollection<ProfessionalSpecialty> ProfessionalSpecialties { get; private set; } // index | para buscar o profissional por tipo de procedimento na hora de agendar

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
