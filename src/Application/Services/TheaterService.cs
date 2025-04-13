using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces.Movies;
using Domain.Interfaces.Theaters;
using Domain.ObjectValues.Movies;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class TheaterService
{
    private readonly ITheaterRepository _repository;
    private readonly ILogger<TheaterService> _logger;

    public TheaterService(ITheaterRepository repository, ILogger<TheaterService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Theater> CreateAsync(TheaterCreate request, CancellationToken token = default)
    {
        return await _repository.CreateAsync(request.ToTheater(), token);
    }

    public async Task<Theater> UpdateAsync(long id, TheaterUpdateValue entity, CancellationToken token = default)
    {
        return await _repository.UpdateAsync(id, entity, token);
    }

    public async Task<Theater> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _repository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<Theater>> GetAllAsync(CancellationToken token = default)
    {
        return await _repository.GetAllAsync(token);
    }
}