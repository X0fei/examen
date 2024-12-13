using System.Text.RegularExpressions;
using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data.Repository;

public class GroupRepository(RemoteDatabaseContext remoteDatabaseContext) : IGroupRepository
{
    public IEnumerable<GroupDao> GetGroups()
    {
        return remoteDatabaseContext.Groups.Include(students => students.Students).ToList();
    }

    public GroupDao? GetGroupById(int id)
    {
        return remoteDatabaseContext.Groups.FirstOrDefault(group => group.Id == id);
    }
}