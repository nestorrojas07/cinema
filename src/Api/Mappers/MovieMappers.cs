using Api.Requests.Movie;
using Domain.Entities;
using Domain.ObjectValues.Movies;

namespace Api.Mappers;

public static class MovieMappers
{
    public static MovieCreate ToMovie(this CreateMovieRequest request)
    {
        return new MovieCreate()
        {
            Title = request.Title,
            Description = request.Description,
            Genre = request.Genre,
            DurationMinutes = request.DurationMinutes,
            LaunchAt = request.LaunchAt,
        };
    } 
    
    public static MovieUpdateValue ToMovieValue(this UpdateMovieRequest request)
    {
        return new MovieUpdateValue()
        {
            Title = request.Title,
            Description = request.Description,
            Genre = request.Genre,
            DurationMinutes = request.DurationMinutes,
            LaunchAt = request.LaunchAt,
        };
    }
    
    
}