using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces.Movies;
using Domain.ObjectValues.Movies;
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

    public Task<Movie> CreateAsync(MovieCreate request, CancellationToken token = default)
    {
        return _repository.CreateAsync(request.ToMovie(), token);
    }

    public Task<Movie> UpdateAsync(long id, MovieUpdateValue entity, CancellationToken token = default)
    {
        return _repository.UpdateAsync(id, entity, token);
    }

    public Task<Movie> GetByIdAsync(long id, CancellationToken token = default)
    {
        return _repository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default)
    {
        return await _repository.GetAllAsync(token);
    }
}