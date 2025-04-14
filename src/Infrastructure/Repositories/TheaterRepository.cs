using Domain.Entities;
using Domain.Interfaces.Movies;
using Domain.Interfaces.Theaters;
using Domain.ObjectValues.Movies;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TheaterRepository : ITheaterRepository
{
    
    private readonly ApplicationDbContext _context;

    public TheaterRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Theater> CreateAsync(Theater entity, CancellationToken token = default)
    {
        entity.CreatedAt = DateTimeOffset.UtcNow;
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        await _context.theaters.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Theater> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _context.theaters.FindAsync(id);
    }

    public async Task<IEnumerable<Theater>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.theaters.ToListAsync(token);
    }

    public async Task<Theater> UpdateAsync(long id, TheaterUpdateValue entity, CancellationToken token = default)
    {
        var theater = await _context.theaters.FindAsync(id);
        if (theater == null)
            throw new KeyNotFoundException("Theater not found");
        theater.Name = !string.IsNullOrEmpty(entity.Name) ? entity.Name : theater.Name;
        theater.Address = !string.IsNullOrEmpty(entity.Address) ? entity.Address : theater.Address;
        theater.Contact = !string.IsNullOrEmpty(entity.Contact) ? entity.Contact : theater.Contact;
        
        theater.UpdatedAt = DateTimeOffset.UtcNow;        
        _context.Entry(theater).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return theater;
    }
}