namespace Api.Requests.ShowSchedules;

public class ReservationSeatRequest
{
    public long ReservationId { get; set; }
    public string Identification { get; set; }
    public string Email { get; set; }
}