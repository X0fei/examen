using data.DAO;

namespace data.Repository;

public class AttendanceTypeRepository(RemoteDatabaseContext remoteDatabaseContext): ITypeAttendanceRepository
{
    public IEnumerable<TypeAttendanceDao> GetAttendanceTypes()
    {
        return remoteDatabaseContext.TypeAttendances;
    }
}