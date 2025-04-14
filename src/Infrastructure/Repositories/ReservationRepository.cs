using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Interfaces.ShowSchedules;
using Domain.ObjectValues.ShowSchedules;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    
    private readonly ApplicationDbContext _context;

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(IEnumerable<Reservation> reservations, CancellationToken token = default)
    {
        foreach (var reservation_part in reservations.Chunk(100))
        {
            await _context.AddRangeAsync(reservation_part);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync(ReservationSearch filter, CancellationToken token = default)
    {
        var query = _context.reservations
            .Include(x => x.Movie)
            .Include(x => x.Hall)
            .AsQueryable();

        //.AsNoTracking()
        if (filter?.ShowScheduleId != null)
            query = query.Where(x => x.ShowScheduleId == filter.ShowScheduleId);
        if (filter?.TheaterId != null)
            query = query.Where(x => x.TheaterId == filter.TheaterId);
        if (filter?.MovieId != null)
            query = query.Where(x => x.MovieId == filter.MovieId);
        if (filter?.Status != null)
            query = query.Where(x => x.Status == filter.Status);
        if (filter is { Start: not null, End: not null })
            query = query.Where(x => x.StartAt >= filter.Start && x.StartAt <= filter.End);
        if (filter?.Identification != null)
            query = query.Where(x => x.Identification.ToLower().Contains(filter.Identification.ToLower()));
        if (filter?.Invoice != null)
            query = query.Where(x => x.Invoice.ToLower().Contains(filter.Invoice.ToLower()));
        if (filter?.Email != null)
            query = query.Where(x => x.Email.ToLower().Contains(filter.Email.ToLower()));
        
        return await query.OrderBy(x => x.StartAt).ToListAsync(token);
    }

    public async Task ChangeStatusAsync(long reservationId, ReservationStatus newStatus, CancellationToken token = default)
    {
        await _context.reservations
            .Where(r => r.Id == reservationId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Status, newStatus)
            );
    }

    public async Task PaymentAsync(ReservationPayment payment, CancellationToken token = default)
    {
        await _context.reservations
            .Where(r => r.Id == payment.ReservationId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Status, ReservationStatus.Payed)
                    .SetProperty(r => r.Invoice, payment.Invoice )
                    .SetProperty(r => r.Identification, payment.Identification )
                    .SetProperty(r => r.Email, payment.Email )
            );
    }

    public async Task ReservationSeatAsync(ReservationSeat reservationSeat, CancellationToken token = default)
    {
        await _context.reservations
            .Where(r => r.Id == reservationSeat.ReservationId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Status, ReservationStatus.Reserved)
                    .SetProperty(r => r.Identification, reservationSeat.Identification )
                    .SetProperty(r => r.Email, reservationSeat.Email )
            );
    }

    public async Task CancelAsync(long reservationId, CancellationToken token = default)
    {
        await _context.reservations
            .Where(r => r.Id == reservationId)
            .ExecuteUpdateAsync(b =>
                b.SetProperty(u => u.Status, ReservationStatus.NoAssigned)
                    .SetProperty(r => r.Invoice, string.Empty )
                    .SetProperty(r => r.Identification, string.Empty  )
                    .SetProperty(r => r.Email, string.Empty  )
            );
    }

    public async Task<Reservation> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _context.reservations.FindAsync(id);
    }
}