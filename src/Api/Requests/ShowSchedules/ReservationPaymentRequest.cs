namespace Api.Requests.ShowSchedules;

public class ReservationPaymentRequest
{
    public long ReservationId { get; set; }
    public string Invoice { get; set; }
    public string Identification { get; set; }
    public string Email { get; set; }
}