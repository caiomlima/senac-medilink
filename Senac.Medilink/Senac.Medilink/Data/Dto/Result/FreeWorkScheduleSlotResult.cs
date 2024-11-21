namespace Senac.Medilink.Data.Dto.Result;

public class FreeWorkScheduleSlotResult
{
    public DateOnly Day { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
