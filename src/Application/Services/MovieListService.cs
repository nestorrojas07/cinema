using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces.MovieLists;
using Domain.ObjectValues.MovieLists;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class MovieListService
{
    private readonly IMovieListRepository _repository;
    private readonly ILogger<MovieListService> _logger;

    public MovieListService(IMovieListRepository repository, ILogger<MovieListService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<MovieList> CreateAsync(MovieListCreate request, CancellationToken token = default)
    {
        return await _repository.CreateAsync(request.ToMovieList(), token);
    }

    public async Task<MovieList> UpdateAsync(long id, MovieListUpdateValue entity, CancellationToken token = default)
    {
        return await _repository.UpdateAsync(id, entity, token);
    }

    public async Task<MovieList> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _repository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<MovieList>> GetAllAsync(CancellationToken token = default)
    {
        return await _repository.GetAllAsync(token);
    }

    public async Task<IEnumerable<MovieList>> GetAllAsync(MovieListSearch filter, CancellationToken token = default)
    {
        return await _repository.GetAllAsync(filter, token);
    }
}