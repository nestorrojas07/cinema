namespace Api.Requests.Movie;

public class CreateMovieRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int DurationMinutes { get; set; }
    public DateTimeOffset LaunchAt { get; set; }
}