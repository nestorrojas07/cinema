using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Api.Requests.MovieLists;

public class CreateMovieListRequest
{
    public long MovieId { get; set; }
    public long TheaterId { get; set; }
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public MovieListStatus Status { get; set; }
}