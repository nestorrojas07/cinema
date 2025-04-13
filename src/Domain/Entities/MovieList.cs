using Domain.Entities.Enums;

namespace Domain.Entities;

public class MovieList
{
    public long Id { get; set; }
    public long MovieId { get; set; }
    public virtual Movie Movie { get; set; }
    public long TheaterId { get; set; }
    public virtual Theater Theater { get; set; }
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
    public MovieListStatus Status { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}