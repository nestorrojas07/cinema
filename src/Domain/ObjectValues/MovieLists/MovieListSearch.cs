using Domain.Entities.Enums;

namespace Domain.ObjectValues.MovieLists;

public class MovieListSearch
{
    public long? MovieId { get; set; }
    public long? TheaterId { get; set; }
    public DateTimeOffset? Start { get; set; }
    public DateTimeOffset? End { get; set; }
    public MovieListStatus? Status { get; set; }
}