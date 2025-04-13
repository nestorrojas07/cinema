using Domain.Entities.Enums;

namespace Api.Requests.MovieLists;

public class MovieListSearchRequest
{
    public long? MovieId { get; set; }
    public long? TheaterId { get; set; }
    public DateTimeOffset? Start { get; set; }
    public DateTimeOffset? End { get; set; }
    public MovieListStatus? Status { get; set; }
}