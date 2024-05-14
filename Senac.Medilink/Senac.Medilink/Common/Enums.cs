namespace Senac.Medilink.Common
{
    public enum ExamStatus
    {
        Pending = 0,
        InProgress = 1,
        Concluded = 2,
        Canceled = 3,
    }

    public enum ScheduleStatus
    {
        Pending = 0,
        Concluded = 1,
        Canceled = 2,
    }

    public enum FormOfService
    {
        Presential = 0,
        Online = 1,
    }

    public enum UserType
    {
        Admin = 1,
        Professional = 2,
        Patient = 3,
    }

    public enum UserRole
    {
        Admin = 1,
        Professional = 2,
        Patient = 3,
    }

    public enum ServiceType
    {
        Schedule = 1,
        Exam = 2,
    }
}
