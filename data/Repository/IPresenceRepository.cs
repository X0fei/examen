using data.DAO;

namespace data.Repository;

public interface IPresenceRepository
{
   public IEnumerable<PresenceDao>? GetAllPresences();
   public bool UpdatePresenceAttendance(PresenceDao oldPresence, TypeAttendanceDao newType);
}