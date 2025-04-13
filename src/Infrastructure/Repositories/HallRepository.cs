using Domain.Entities;
using Domain.Interfaces.Theaters;
using Domain.ObjectValues.Halls;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class HallRepository : IHallRepository
{
    
    private readonly ApplicationDbContext _context;

    public HallRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Hall> CreateAsync(Hall entity, CancellationToken token = default)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        entity.Seats = entity.Rows * entity.Columns;
        await _context.halls.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Hall> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _context.halls.FindAsync(id);
    }

    public async Task<IEnumerable<Hall>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.halls.ToListAsync(token);
    }

    public async Task<IEnumerable<Hall>> GetAllAsync(HallSearch filter, CancellationToken token = default)
    {
        var query = _context.halls.AsQueryable();

        //.AsNoTracking()
        if (filter?.TheaterId != null)
            query = query.Where(x => x.TheaterId == filter.TheaterId);
        if (filter?.Name != null)
            query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        return await query.ToListAsync(token);
    }

    public async Task<Hall> UpdateAsync(long id, HallUpdateValue entity, CancellationToken token = default)
    {
        var hall = await _context.halls.FindAsync(id);
        if (hall == null)
            throw new KeyNotFoundException("Hall not found");
        
        hall.Name = !string.IsNullOrEmpty(entity.Name) ? entity.Name : hall.Name;
        hall.Rows = entity.Rows ?? hall.Rows;
        hall.Columns = entity.Columns ?? hall.Columns;
        hall.Seats = hall.Rows * hall.Columns;
        
        hall.UpdatedAt = DateTimeOffset.UtcNow;        
        _context.Entry(hall).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return hall;
    }
}