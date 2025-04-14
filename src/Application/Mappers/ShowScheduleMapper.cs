using Domain.Entities;
using Domain.ObjectValues.ShowSchedules;

namespace Application.Mappers;

public static class ShowScheduleMapper
{

    public static ShowSchedule ToShowSchedule(this ShowScheduleCreate request, MovieList movieList, Hall hall)
    {
        return new ShowSchedule()
        {
            MovieId = movieList.MovieId,
            TheaterId = movieList.TheaterId,
            From = request.StartAt,
            To = request.EndAt,
            Status = request.Status,
            SeatsAvailable = hall.Seats,
            SeatsSold = 0,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        };
    }
}