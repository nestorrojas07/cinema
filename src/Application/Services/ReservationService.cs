using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Exceptions;
using Domain.Interfaces.ShowSchedules;
using Domain.ObjectValues.ShowSchedules;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class ReservationService
{
    private readonly IReservationRepository _repository;
    private readonly IShowScheduleRepository _showScheduleRepository;
    private readonly ILogger<ReservationService> _logger;

    public ReservationService(IReservationRepository repository, IShowScheduleRepository showScheduleRepository, 
        ILogger<ReservationService> logger)
    {
        _repository = repository;
        _showScheduleRepository = showScheduleRepository;
        _logger = logger;
    }

    public async Task ReservationSeatAsync(ReservationSeat reservationSeat, CancellationToken token = default)
    {
        Reservation reservation  = await _repository.GetByIdAsync(reservationSeat.ReservationId);
        if (reservation == null)
            throw new KeyNotFoundException("Reservation no encontrado");
        if(reservation.Status != ReservationStatus.NoAssigned)
            throw new DomainException("Seat with Invalid Status");

        await _repository.ReservationSeatAsync(reservationSeat, token);
        await _showScheduleRepository.IncrementSeatsStaticsticsAsyc(reservation.ShowScheduleId, -1, 1, token);
    }

    public async Task AddAsync(IEnumerable<Reservation> reservations, CancellationToken token = default)
    {
        await _repository.AddAsync(reservations, token);
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync(ReservationSearch filter, CancellationToken token = default)
    {
        return await _repository.GetAllAsync(filter, token);
    }

    public async Task ChangeStatusAsync(long reservationId, ReservationStatus newStatus, CancellationToken token = default)
    {
        await _repository.ChangeStatusAsync(reservationId, newStatus, token);
    }

    public async Task PaymentAsync(ReservationPayment payment, CancellationToken token = default)
    {
        await _repository.PaymentAsync(payment, token);
    }

    public async Task CancelAsync(long reservationId, CancellationToken token = default)
    {
        await _repository.CancelAsync(reservationId, token);
        Reservation reservation  = await _repository.GetByIdAsync(reservationId);
        await _showScheduleRepository.IncrementSeatsStaticsticsAsyc(reservation.ShowScheduleId, 1, -1, token);
    }

    public async Task<Reservation> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _repository.GetByIdAsync(id, token);
    }
}