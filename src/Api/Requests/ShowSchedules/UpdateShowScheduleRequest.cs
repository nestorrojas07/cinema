using Domain.Entities.Enums;

namespace Api.Requests.ShowSchedules;

public class UpdateShowScheduleRequest
{
    public long? MovieId { get; set; }
    public long? TheaterId { get; set; }
    public DateTimeOffset? From { get; set; }
    public DateTimeOffset? To { get; set; }
    public ShowScheduleStatus? Status { get; set; }
}