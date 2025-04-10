using Domain.Entities;
using Domain.Interfaces.Core;

namespace Domain.Interfaces.Movies;

public interface IMovieRepository : ICreate<Movie>, IUpdate<Movie>, IRead<Movie>
{
    
}