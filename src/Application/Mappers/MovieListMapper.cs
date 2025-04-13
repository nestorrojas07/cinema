using Domain.Entities;
using Domain.ObjectValues.MovieLists;

namespace Application.Mappers;

public static class MovieListMapper
{

    public static MovieList ToMovieList(this MovieListCreate request)
    {
        return new MovieList()
        {
            MovieId = request.MovieId,
            TheaterId = request.TheaterId,
            From = request.From,
            To = request.To,
            Status = request.Status,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        };
    }
}