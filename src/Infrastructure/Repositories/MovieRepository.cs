using Domain.Entities;
using Domain.Interfaces.Movies;
using Domain.ObjectValues.Movies;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    
    private readonly ApplicationDbContext _context;

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> CreateAsync(Movie entity, CancellationToken token = default)
    {
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        await _context.movies.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Movie> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _context.movies.FindAsync(id);
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default)
    {
        return await _context.movies.Where(x => x.LaunchAt >= DateTime.UtcNow).ToListAsync(token);
    }

    public async Task<Movie> UpdateAsync(long id, MovieUpdateValue entity, CancellationToken token = default)
    {
        var movie = await _context.movies.FindAsync(id);
        if (movie == null)
            throw new KeyNotFoundException("Movie not found");
        
        movie.Title = entity.Title ?? movie.Title;
        movie.Description = entity.Description ?? movie.Description;
        movie.Genre = entity.Genre ?? movie.Genre;
        movie.DurationMinutes = entity.DurationMinutes ?? movie.DurationMinutes;
        movie.LaunchAt = entity.LaunchAt ?? movie.LaunchAt;
        movie.UpdatedAt = DateTime.UtcNow;        
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return movie;
    }
}