using Api.Requests.ShowSchedules;
using Domain.ObjectValues.ShowSchedules;

namespace Api.Mappers;

public static class ReservationMapper
{
    public static ReservationSearch ToReservationSearch(this ReservationSearchRequest request)
    {
        return new ReservationSearch()
        {
            ShowScheduleId = request.ShowScheduleId,
            TheaterId = request.TheaterId,
            MovieId = request.MovieId,
            Invoice = request.Invoice,
            Email = request.Email,
            End = request.End,
            Start = request.Start,
            Identification = request.Identification,
            Status = request.Status,
        };
    }

    public static ReservationSeat ToReservationSeat(this ReservationSeatRequest request)
    {
        return new ReservationSeat()
        {
            ReservationId = request.ReservationId,
            Email = request.Email,
            Identification = request.Identification,
        };
    }

    public static ReservationPayment ToReservationPayment(this ReservationPaymentRequest request)
    {
        return new ReservationPayment()
        {
            ReservationId = request.ReservationId,
            Email = request.Email,
            Identification = request.Identification,
            Invoice = request.Invoice,
        };
    }
}