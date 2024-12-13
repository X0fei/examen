using data.DAO;

namespace data.Repository;

public interface IUserRepository
{
     bool RemoveUserByGuid(Guid guid);
     bool RemoveUsersByGroupId(int groupId);
}