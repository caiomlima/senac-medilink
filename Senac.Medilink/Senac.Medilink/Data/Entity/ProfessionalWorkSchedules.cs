using Senac.Medilink.Data.Entity.Common;
using Senac.Medilink.Data.Entity.User;

namespace Senac.Medilink.Data.Entity;

public class ProfessionalWorkSchedules : BaseEntity // TODO nome meio pá, mas td bem
{
    public ProfessionalWorkSchedules() { }

    public ProfessionalWorkSchedules(
        DayOfWeek dayOfWeek,
        TimeSpan startTime,
        TimeSpan endTime,
        long professionalId,
        long unitId)
    {
        DayOfWeek = dayOfWeek;
        StartTime = startTime;
        EndTime = endTime;
        ProfessionalId = professionalId;
        UnitId = unitId;
    }

    public long ProfessionalId { get; private set; }
    public long UnitId { get; private set; }
    public long ProfessionalSpecialtyId { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }

    public virtual Professional Professional { get; private set; }
    public virtual Unit Unit { get; private set; }

    public bool ScheduleOverlap(DateTime startTime, DateTime endTime)
    {
        return StartTime < endTime.TimeOfDay && startTime.TimeOfDay < EndTime;
    }
}
