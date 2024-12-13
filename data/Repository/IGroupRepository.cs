using data.DAO;

namespace data.Repository;

public interface IGroupRepository
{
    public IEnumerable<GroupDao> GetGroups();
    public GroupDao? GetGroupById(int id);
}