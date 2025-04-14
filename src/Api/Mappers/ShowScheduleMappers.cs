using Api.Requests.ShowSchedules;
using Domain.ObjectValues.ShowSchedules;

namespace Api.Mappers;

public static class ShowScheduleMapper
{
    public static ShowScheduleCreate ToShowScheduleCreate(this CreateShowScheduleRequest request)
    {
        return new ShowScheduleCreate()
        {
            MovieListId = request.MovieListId,
            HallId = request.HallId,
            StartAt = request.StartAt,
            EndAt = request.EndAt,
            Status = request.Status,
        };
    }

    public static ShowScheduleUpdateValue ToShowScheduleValue(this UpdateShowScheduleRequest request)
    {
        return new ShowScheduleUpdateValue()
        {
           From = request.From,
           To = request.To,
           Status = request.Status
        };
    }
    public static ShowScheduleSearch ToShowScheduleSearch(this ShowScheduleSearchRequest request)
    {
        return new ShowScheduleSearch()
        {
            MovieId = request.MovieId,
            TheaterId = request.TheaterId,
            Start = request.Start,
            End = request.End,
            Status = request.Status
        };
    }
    
    
}