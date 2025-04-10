namespace Api.Requests.Movie;

public class UpdateMovieRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Genre { get; set; }
    public int? DurationMinutes { get; set; }
    public DateTime? LaunchAt { get; set; }
}