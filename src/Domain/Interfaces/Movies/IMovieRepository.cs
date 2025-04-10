using Domain.Entities;
using Domain.Interfaces.Core;
using Domain.ObjectValues.Movies;

namespace Domain.Interfaces.Movies;

public interface IMovieRepository : ICreate<Movie>, IUpdate<MovieUpdateValue, long, Movie>, IRead<Movie>
{
    Task<IEnumerable<Movie>> GetAllAsync(CancellationToken token = default);
}