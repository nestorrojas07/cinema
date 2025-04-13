using Domain.Entities;
using Domain.ObjectValues.ShowSchedules;

namespace Application.Mappers;

public static class ShowScheduleMapper
{

    public static ShowSchedule ToShowSchedule(this ShowScheduleCreate request)
    {
        return new ShowSchedule()
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