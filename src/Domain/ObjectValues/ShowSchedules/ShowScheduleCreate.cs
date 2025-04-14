using Domain.Entities.Enums;

namespace Domain.ObjectValues.ShowSchedules;

public class ShowScheduleCreate
{
    public long MovieListId { get; set; }
    public long HallId { get; set; }
    public DateTimeOffset StartAt { get; set; }
    public DateTimeOffset EndAt { get; set; }
    public ShowScheduleStatus Status { get; set; }
}