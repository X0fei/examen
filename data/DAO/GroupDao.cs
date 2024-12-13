namespace data.DAO;

public class GroupDao
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual IEnumerable<StudentDao>? Students { get; set; }
}