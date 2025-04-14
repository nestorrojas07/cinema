using Domain.Entities.Enums;

namespace Domain.Entities;

public class Reservation
{
    public long Id { get; set; }
    public long ShowScheduleId { get; set; }
    public virtual ShowSchedule ShowSchedule { get; set; }
    public long MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public long HallId { get; set; }
    public virtual Hall Hall { get; set; }
    public long TheaterId { get; set; }
    public virtual Theater Theater { get; set; }
    public DateTimeOffset StartAt { get; set; }
    public DateTimeOffset EndAt { get; set; }
    public string Location { get; set; }
    public string Invoice { get; set; }
    public string Identification { get; set; }
    public string Email { get; set; }
    public ReservationStatus Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}