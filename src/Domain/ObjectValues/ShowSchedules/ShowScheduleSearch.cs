using Domain.Entities.Enums;

namespace Domain.ObjectValues.ShowSchedules;

public class ShowScheduleSearch
{
    public long? MovieId { get; set; }
    public long? TheaterId { get; set; }
    public DateTimeOffset? Start { get; set; }
    public DateTimeOffset? End { get; set; }
    public ShowScheduleStatus? Status { get; set; }
}