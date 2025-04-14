
using Domain.Entities.Enums;

namespace Domain.ObjectValues.ShowSchedules;

public class ShowScheduleUpdateValue 
{
    public DateTimeOffset? From { get; set; }
    public DateTimeOffset? To { get; set; }
    public ShowScheduleStatus? Status { get; set; }
}