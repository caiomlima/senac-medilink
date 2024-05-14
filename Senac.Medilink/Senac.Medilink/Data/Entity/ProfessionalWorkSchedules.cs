using Senac.Medilink.Data.Entity.Common;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Entity
{
    public class ProfessionalWorkSchedules : BaseEntity // TODO nome meio pá, mas td bem
    {
        public ProfessionalWorkSchedules() { }

        public ProfessionalWorkSchedules(
            DayOfWeek dayOfWeek,
            TimeSpan startTime,
            TimeSpan endTime,
            long professionalId)
        {
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            ProfessionalId = professionalId;
            Professionals = new List<Professional>();
            Units = new List<Unit>();
        }

        public DayOfWeek DayOfWeek { get; private set; }
        public TimeSpan StartTime { get; private set; } // TODO verificar isso, se não time span é melhor
        public TimeSpan EndTime { get; private set; } // TODO verificar isso, se não time span é melhor
        public long ProfessionalId { get; private set; }

        public virtual ICollection<Professional> Professionals { get; private set; }
        public virtual ICollection<Unit> Units { get; private set; }
    }
}
