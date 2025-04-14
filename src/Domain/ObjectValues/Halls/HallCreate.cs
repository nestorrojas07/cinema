namespace Domain.ObjectValues.Halls;

public class HallCreate
{
    public string Name { get; set; }
    public long TheaterId { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
}