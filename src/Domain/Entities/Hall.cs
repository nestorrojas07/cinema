namespace Domain.Entities;

public class Hall
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long TheaterId { get; set; }
    public virtual Theater Theater { get; set; }
    public int Seats { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    
}