using Domain.Entities;
using Domain.ObjectValues.Movies;

namespace Application.Mappers;

public static class MovieMapper
{

    public static Movie ToMovie(this MovieCreate request)
    {
        return new Movie()
        {
            Title = request.Title,
            Description = request.Description,
            Genre = request.Genre,
            DurationMinutes = request.DurationMinutes,
            LaunchAt = request.LaunchAt,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}