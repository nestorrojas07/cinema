using Domain.Entities;
using Domain.ObjectValues.Halls;
using Domain.ObjectValues.Movies;

namespace Application.Mappers;

public static class HallMapper
{

    public static Hall ToHall(this HallCreate request)
    {
        return new Hall()
        {
            Name = request.Name,
            TheaterId = request.TheaterId,
            Columns = request.Columns,
            Rows = request.Rows,
            Seats = request.Columns * request.Rows,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        };
    }
}