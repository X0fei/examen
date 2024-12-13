namespace data.DAO;

public class PresenceDao
{
    public int LessonNumber { get; set; }
    public virtual required  TypeAttendanceDao TypeAttendance { get; set; }
    public virtual required  SubjectDao Subject { get; set; }
    public int TypeAttendanceId { get; set; }
    public int SubjectId { get; set; }
    public Guid StudentGuid { get; set; }
    public required StudentDao Student { get; set; }
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}