using Domain.Entities;
using Domain.Interfaces.ShowSchedules;
using Domain.ObjectValues.ShowSchedules;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ShowScheduleRepository : IShowScheduleRepository
{
    
    private readonly ApplicationDbContext _context;

    public ShowScheduleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShowSchedule> CreateAsync(ShowSchedule entity, CancellationToken token = default)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        await _context.showSchedules.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<ShowSchedule> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _context.showSchedules.FindAsync(id);
    }

    public async Task<IEnumerable<ShowSchedule>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.showSchedules.ToListAsync(token);
    }

    public async Task<IEnumerable<ShowSchedule>> GetAllAsync(ShowScheduleSearch filter, CancellationToken token = default)
    {
        var query = _context.showSchedules
            .Include(x => x.Movie)
            .Include(x => x.Theater)
            .AsQueryable();

        //.AsNoTracking()
        if (filter?.TheaterId != null)
            query = query.Where(x => x.TheaterId == filter.TheaterId);
        if (filter?.MovieId != null)
            query = query.Where(x => x.MovieId == filter.MovieId);
        if (filter?.Status != null)
            query = query.Where(x => x.Status == filter.Status);
        
        if (filter is { Start: not null, End: not null })
            query = query.Where(x => (filter.Start >= x.From && filter.Start <= x.To) && (filter.End >= x.From && filter.End <= x.To));
        
        return await query.OrderBy(x => x.From).ToListAsync(token);
    }

    public async Task<ShowSchedule> UpdateAsync(long id, ShowScheduleUpdateValue entity, CancellationToken token = default)
    {
        var show = await _context.showSchedules.FindAsync(id);
        if (show == null)
            throw new KeyNotFoundException("ShowSchedule not found");
        
        show.MovieId = entity.MovieId ?? show.MovieId;
        show.From = entity.From ?? show.From;
        show.To = entity.To ?? show.To;
        show.Status = entity.Status ?? show.Status;
        
        show.UpdatedAt = DateTimeOffset.UtcNow;        
        _context.Entry(show).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return show;
    }
}