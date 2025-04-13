namespace Api.Requests.Hall;

public class CreateHallRequest
{
    public string? Name { get; set; }
    public long TheaterId { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
}