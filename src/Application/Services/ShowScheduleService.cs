using Application.Mappers;
using Domain.Entities;
using Domain.Interfaces.ShowSchedules;
using Domain.ObjectValues.ShowSchedules;
using Microsoft.Extensions.Logging;

namespace Application.Services;

public class ShowScheduleService
{
    private readonly IShowScheduleRepository _repository;
    private readonly ILogger<ShowScheduleService> _logger;

    public ShowScheduleService(IShowScheduleRepository repository, ILogger<ShowScheduleService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ShowSchedule> CreateAsync(ShowScheduleCreate request, CancellationToken token = default)
    {
        return await _repository.CreateAsync(request.ToShowSchedule(), token);
    }

    public async Task<ShowSchedule> UpdateAsync(long id, ShowScheduleUpdateValue entity, CancellationToken token = default)
    {
        return await _repository.UpdateAsync(id, entity, token);
    }

    public async Task<ShowSchedule> GetByIdAsync(long id, CancellationToken token = default)
    {
        return await _repository.GetByIdAsync(id, token);
    }

    public async Task<IEnumerable<ShowSchedule>> GetAllAsync(CancellationToken token = default)
    {
        return await _repository.GetAllAsync(token);
    }

    public async Task<IEnumerable<ShowSchedule>> GetAllAsync(ShowScheduleSearch filter, CancellationToken token = default)
    {
        return await _repository.GetAllAsync(filter, token);
    }
}