namespace Domain.Entities;

public class Theater
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}
