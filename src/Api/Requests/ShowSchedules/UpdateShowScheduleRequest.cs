using Domain.Entities.Enums;

namespace Api.Requests.ShowSchedules;

public class UpdateShowScheduleRequest
{
    public DateTimeOffset? From { get; set; }
    public DateTimeOffset? To { get; set; }
    public ShowScheduleStatus? Status { get; set; }
}