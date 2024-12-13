namespace data.DAO;

public class StudentDao
{
    public Guid Guid { get; set; }
    public required string  Name { get; set; }
    public virtual GroupDao? Group { get; set; }
}