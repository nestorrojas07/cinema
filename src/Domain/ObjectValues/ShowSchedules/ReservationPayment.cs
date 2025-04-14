namespace Domain.ObjectValues.ShowSchedules;

public class ReservationPayment
{
    public long ReservationId { get; set; }
    public string Invoice { get; set; }
    public string Identification { get; set; }
    public string Email { get; set; }
}