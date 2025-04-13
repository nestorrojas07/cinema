namespace Api.Requests.Hall;

public class UpdateHallRequest
{
    public string? Name { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
}