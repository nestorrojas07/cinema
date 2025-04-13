using Domain.Entities.Enums;

namespace Api.Requests.ShowSchedules;

public class ShowScheduleSearchRequest
{
    public long? MovieId { get; set; }
    public long? TheaterId { get; set; }
    public DateTimeOffset? Start { get; set; }
    public DateTimeOffset? End { get; set; }
    public ShowScheduleStatus? Status { get; set; }
}