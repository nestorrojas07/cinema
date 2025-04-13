using Domain.Entities.Enums;

namespace Domain.ObjectValues.MovieLists;

public class MovieListCreate
{
    public long MovieId { get; set; }
    public long TheaterId { get; set; }
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public MovieListStatus Status { get; set; }
}