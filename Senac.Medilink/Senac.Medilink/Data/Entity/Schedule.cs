using Senac.Medilink.Common;
using Senac.Medilink.Data.Entity.Common;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Entity
{
    public class Schedule : BaseEntity
    {
        public Schedule() { }

        public Schedule(
            long patientId,
            long professionalId,
            long specialtyId,
            long unitId,
            DateTime startDate,
            DateTime endDate,
            FormOfService formOfService,
            ServiceType type)
        {
            PatientId = patientId;
            ProfessionalId = professionalId;
            SpecialtyId = specialtyId;
            UnitId = unitId;
            StartDate = startDate;
            EndDate = endDate;
            Type = type; 
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Status = ScheduleStatus.Pending;
            Form = formOfService;
            Active = true;
        }

        public long PatientId { get; private set; }
        public long ProfessionalId { get; private set; }
        public long SpecialtyId { get; private set; }
        public long UnitId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public ServiceType Type { get; private set; }
        public ScheduleStatus Status { get; private set; }
        public FormOfService Form { get; private set; }
        public string Result { get; private set; }
        public bool Active { get; private set; }

        public virtual Patient Patient { get; private set; }
        public virtual Professional Professional { get; private set; }
        public virtual Unit Unit { get; private set; }

        internal void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.UtcNow;
        }

        internal void SetStatusConcluded()
        {
            Status = ScheduleStatus.Concluded;
            UpdatedAt = DateTime.UtcNow;
        }

        internal void SetStatusCanceled()
        {
            Status = ScheduleStatus.Canceled;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
