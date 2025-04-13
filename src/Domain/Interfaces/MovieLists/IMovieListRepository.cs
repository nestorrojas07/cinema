using Domain.Entities;
using Domain.Interfaces.Core;
using Domain.ObjectValues.MovieLists;

namespace Domain.Interfaces.MovieLists;

public interface IMovieListRepository : ICreate<MovieList>, IUpdate<MovieListUpdateValue, long, MovieList>, IRead<MovieList>
{
    Task<IEnumerable<MovieList>> GetAllAsync(CancellationToken token = default);
    Task<IEnumerable<MovieList>> GetAllAsync(MovieListSearch filter,CancellationToken token = default);
}