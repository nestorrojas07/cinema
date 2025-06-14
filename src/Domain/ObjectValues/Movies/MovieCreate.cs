﻿namespace Domain.ObjectValues.Movies;

public class MovieCreate
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int DurationMinutes { get; set; }
    public DateTimeOffset LaunchAt { get; set; }
}