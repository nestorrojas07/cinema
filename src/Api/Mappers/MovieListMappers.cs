using Api.Requests.MovieLists;
using Domain.ObjectValues.MovieLists;

namespace Api.Mappers;

public static class MovieListMapper
{
    public static MovieListCreate ToMovieListCreate(this CreateMovieListRequest request)
    {
        return new MovieListCreate()
        {
            MovieId = request.MovieId,
            TheaterId = request.TheaterId,
            From = request.From,
            To = request.To,
            Status = request.Status,
        };
    }

    public static MovieListUpdateValue ToMovieListValue(this UpdateMovieListRequest request)
    {
        return new MovieListUpdateValue()
        {
           MovieId = request.MovieId,
           TheaterId = request.TheaterId,
           From = request.From,
           To = request.To,
           Status = request.Status
        };
    }
    public static MovieListSearch ToMovieListSearch(this MovieListSearchRequest request)
    {
        return new MovieListSearch()
        {
            MovieId = request.MovieId,
            TheaterId = request.TheaterId,
            Start = request.Start,
            End = request.End,
            Status = request.Status
        };
    }
    
    
}