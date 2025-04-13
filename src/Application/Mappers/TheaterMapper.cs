using Domain.Entities;
using Domain.ObjectValues.Movies;

namespace Application.Mappers;

public static class TheaterMapper
{

    public static Theater ToTheater(this TheaterCreate request)
    {
        return new Theater()
        {
            Name = request.Name,
            Address = request.Address,
            Contact = request.Contact,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
        };
    }
}