using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces.Movies;
using Domain.Interfaces.Theaters;
using Domain.ObjectValues.Halls;
using Domain.ObjectValues.Movies;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class HallService
{
    private readonly IHallRepository _repository;
    private readonly ILogger<HallService> _logger;

    public HallService(IHallRepository repository, ILogger<HallService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<Hall> CreateAsync(HallCreate request, CancellationToken token = default)
    {
        return await _repository.CreateAsync(request.ToHall(), token);
    }

    public async Task<Hall> UpdateAsync(long id, HallUpdateValue entity, CancellationToken token = default)
    {
        return await _repository.UpdateAsync(id, entity, token);
    }

    public async Task<Hall> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _repository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<Hall>> GetAllAsync(CancellationToken token = default)
    {
        return await _repository.GetAllAsync(token);
    }

    public async Task<IEnumerable<Hall>> GetAllAsync(HallSearch filter, CancellationToken token = default)
    {
        return await _repository.GetAllAsync(filter, token);
    }
}