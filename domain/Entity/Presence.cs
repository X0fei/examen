namespace domain.Entity;


public class Presence
{
    public required Subject Subject { get; set; }
    public required Student Student { get; set; }
    public required TypeAttendance TypeAttendance {get; set;}
    public DateOnly Date { get; set; }
    public int LessonNumber { get; set; }  
}