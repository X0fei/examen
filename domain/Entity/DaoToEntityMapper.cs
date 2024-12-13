using data.DAO;

namespace domain.Entity;

public static class DaoToEntityMapper
{
    public static Student StudentDaoToStudent(StudentDao studentDao)
    {
        return new Student{
            Guid = studentDao.Guid, 
            Name = studentDao.Name};
    }
    public static Subject SubjectDaoToSubject(SubjectDao subjectDao)
    {
        return new Subject{
            Id = subjectDao.Id, 
            Name = subjectDao.Name};
    }
    public static TypeAttendance TypeAttendanceDaoToTypeAttendance(TypeAttendanceDao typeAttendanceDao)
    {
        return new TypeAttendance{ 
            Id= typeAttendanceDao.Id, 
            Name = typeAttendanceDao.Name};
    }
    public static Group GroupDaoToGroup(GroupDao groupDao)
    {
        return new Group
        {
            Id = groupDao.Id,
            Name = groupDao.Name,
            Students = groupDao.Students!.Select(StudentDaoToStudent).ToList()
        };
    }

    public static Presence PresenceDaoToPresence(PresenceDao presenceDao)
    {
        return new Presence
        {
            Date = presenceDao.Date,
            LessonNumber = presenceDao.LessonNumber,
            Student = StudentDaoToStudent(presenceDao.Student),
            Subject = SubjectDaoToSubject(presenceDao.Subject),
            TypeAttendance = TypeAttendanceDaoToTypeAttendance(presenceDao.TypeAttendance)
        };
    }
}