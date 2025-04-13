using Api.Requests.ShowSchedules;
using Domain.ObjectValues.ShowSchedules;

namespace Api.Mappers;

public static class ShowScheduleMapper
{
    public static ShowScheduleCreate ToShowScheduleCreate(this CreateShowScheduleRequest request)
    {
        return new ShowScheduleCreate()
        {
            MovieId = request.MovieId,
            TheaterId = request.TheaterId,
            From = request.From,
            To = request.To,
            Status = request.Status,
        };
    }

    public static ShowScheduleUpdateValue ToShowScheduleValue(this UpdateShowScheduleRequest request)
    {
        return new ShowScheduleUpdateValue()
        {
           MovieId = request.MovieId,
           TheaterId = request.TheaterId,
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