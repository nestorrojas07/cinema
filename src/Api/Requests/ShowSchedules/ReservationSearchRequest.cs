using Domain.Entities.Enums;

namespace Api.Requests.ShowSchedules;

public class ReservationSearchRequest
{
    public long? MovieId { get; set; }
    public long? TheaterId { get; set; }
    public long? ShowScheduleId { get; set; }
    public DateTimeOffset? Start { get; set; }
    public DateTimeOffset? End { get; set; }
    public ReservationStatus? Status { get; set; }
    public string? Identification { get; set; }
    public string? Email { get; set; }
    public string? Invoice { get; set; }
}