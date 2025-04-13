using Api.Requests.Movie;
using Api.Requests.Theater;
using Domain.Entities;
using Domain.ObjectValues.Movies;

namespace Api.Mappers;

public static class TheaterMapper
{
    public static TheaterCreate ToTheaterCreate(this CreateTheaterRequest request)
    {
        return new TheaterCreate()
        {
           Name = request.Name,
           Address = request.Address,
           Contact = request.Contact,
        };
    } 
    
    public static TheaterUpdateValue ToTheaterValue(this UpdateTheaterRequest request)
    {
        return new TheaterUpdateValue()
        {
            Name = request.Name,
            Address = request.Address,
            Contact = request.Contact,
        };
    }
    
    
}