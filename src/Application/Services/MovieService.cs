using Domain.Entities;
using Domain.Interfaces.Movies;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class MovieService
{
    private readonly IMovieRepository _repository;
    private readonly ILogger<MovieService> _logger;

    public MovieService(IMovieRepository repository, ILogger<MovieService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public Task<Movie> CreateAsync(Movie entity, CancellationToken token = default)
    {
        return _repository.CreateAsync(entity, token);
    }

    public Task<Movie> UpdateAsync(Movie entity, CancellationToken token = default)
    {
        return _repository.UpdateAsync(entity, token);
    }

    public Task<Movie> GetByIdAsync(long id, CancellationToken token = default)
    {
        return _repository.GetByIdAsync(id, token);
    }
}