using Domain.Entities;
using Domain.Interfaces.Core;
using Domain.ObjectValues.Halls;

namespace Domain.Interfaces.Theaters;

public interface IHallRepository : ICreate<Hall>, IUpdate<HallUpdateValue, long, Hall>, IRead<Hall>
{
    Task<IEnumerable<Hall>> GetAllAsync(CancellationToken token = default);
}