using domain.Entity;

namespace domain.Requests;

public class TypeAttendanceUpdateRequest
{
    public int LessonNumber { get; set; }
    public int SubjectId { get; set; }
    public Guid StudentGuid { get; set; }
    public DateOnly Date { get; set; }
    public int NewTypeAttendanceId { get; set; }
}