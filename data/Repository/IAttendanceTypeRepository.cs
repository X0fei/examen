using data.DAO;

namespace data.Repository;

public interface  ITypeAttendanceRepository
{
    IEnumerable<TypeAttendanceDao> GetAttendanceTypes();
}