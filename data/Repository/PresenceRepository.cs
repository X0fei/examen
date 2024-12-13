using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data.Repository;

public class PresenceRepository(RemoteDatabaseContext remoteDatabaseContext): IPresenceRepository
{
    public IEnumerable<PresenceDao>? GetAllPresences()
    {
        return remoteDatabaseContext.Presences
            .Include(presence => presence.Student)
            .ThenInclude(student => student.Group)
            .Include(presence => presence.Subject)
            .Include(presence => presence.TypeAttendance)
            .ToList();
    }

    public bool UpdatePresenceAttendance(PresenceDao oldPresence, TypeAttendanceDao newType)
    {
        var presence = remoteDatabaseContext.Presences.Find(
            oldPresence.Date,
            oldPresence.LessonNumber,
            oldPresence.StudentGuid,
            oldPresence.SubjectId
          );
        if (presence == null) return false;
        presence.TypeAttendanceId = newType.Id;
        remoteDatabaseContext.Presences.Update(presence);
        return remoteDatabaseContext.SaveChanges() > 0;
    }
}