using System.Text.RegularExpressions;
using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data.Repository;

public class GroupRepository(RemoteDatabaseContext remoteDatabaseContext) : IGroupRepository
{
    public IEnumerable<GroupDao> GetGroups()
    {
        throw new NotImplementedException();
    }

    public GroupDao? GetGroupById(int id)
    {
        throw new NotImplementedException();
    }
}