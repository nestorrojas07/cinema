using Domain.Entities;
using Domain.Interfaces.Core;
using Domain.ObjectValues.Movies;

namespace Domain.Interfaces.Theaters;

public interface ITheaterRepository : ICreate<Theater>, IUpdate<TheaterUpdateValue, long, Theater>, IRead<Theater>
{
    Task<IEnumerable<Theater>> GetAllAsync(CancellationToken token = default);
}