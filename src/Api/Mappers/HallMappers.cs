using Api.Requests.Hall;
using Domain.ObjectValues.Halls;

namespace Api.Mappers;

public static class HallMapper
{
    public static HallCreate ToHallCreate(this CreateHallRequest request)
    {
        return new HallCreate()
        {
            Name = request.Name!,
            Columns = request.Columns,
            Rows = request.Rows,
            TheaterId = request.TheaterId
        };
    }

    public static HallUpdateValue ToHallValue(this UpdateHallRequest request)
    {
        return new HallUpdateValue()
        {
            Name = request.Name!,
            Columns = request.Columns,
            Rows = request.Rows,
        };
    }
    public static HallSearch ToHallSearch(this HallSearchRequest request)
    {
        return new HallSearch()
        {
            Name = request.Name!,
            TheaterId = request.TheaterId
        };
    }
    
    
}