using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.Core;
using Domain.ObjectValues.ShowSchedules;

namespace Domain.Interfaces.ShowSchedules;

public interface IReservationRepository : IRead<Reservation>
{
    Task AddAsync(IEnumerable<Reservation> reservations, CancellationToken token = default);
    Task<IEnumerable<Reservation>> GetAllAsync(ReservationSearch filter,CancellationToken token = default);
    Task ChangeStatusAsync(long reservationId, ReservationStatus newStatus ,CancellationToken token = default);
    Task PaymentAsync(ReservationPayment payment,CancellationToken token = default);
    Task ReservationSeatAsync(ReservationSeat reservationSeat,CancellationToken token = default);
    Task CancelAsync(long reservationId, CancellationToken token = default);
}