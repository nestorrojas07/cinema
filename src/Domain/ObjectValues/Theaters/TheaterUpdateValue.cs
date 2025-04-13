using Domain.Interfaces.Theaters;

namespace Domain.ObjectValues.Movies;

public class TheaterUpdateValue 
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
}