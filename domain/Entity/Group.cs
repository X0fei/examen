namespace domain.Entity;

public class Group
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public IEnumerable<Student>? Students { get; set; }
}