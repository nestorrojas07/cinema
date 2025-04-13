
using Domain.Entities.Enums;

namespace Domain.ObjectValues.ShowSchedules;

public class ShowScheduleUpdateValue 
{
    public long? MovieId { get; set; }
    public long? TheaterId { get; set; }
    public DateTimeOffset? From { get; set; }
    public DateTimeOffset? To { get; set; }
    public ShowScheduleStatus? Status { get; set; }
}