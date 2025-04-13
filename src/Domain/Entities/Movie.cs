namespace Domain.Entities;

public class Movie
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int DurationMinutes { get; set; }
    public DateTimeOffset LaunchAt { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; }
}