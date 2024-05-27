using Senac.Medilink.Data.Entity.Common;

namespace Senac.Medilink.Data.Entity.User
{
    public class Patient : BaseEntity
    {
        public Patient() { }

        public Patient(string name, string document)
        {
            Name = name;
            Document = document;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Active = true;
            Schedules = new List<Schedule>();
        }

        public string Name { get; private set; }
        public string Document { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }

        public virtual User User { get; private set; }
        public virtual ICollection<Schedule> Schedules { get; private set; }

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.Now;
        }
    }
}
