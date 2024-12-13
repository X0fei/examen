using System.Text.RegularExpressions;
using data.DAO;
using Microsoft.EntityFrameworkCore;

namespace data.Repository;

public class UserRepository(RemoteDatabaseContext remoteDatabaseContext) : IUserRepository
{
    public bool RemoveUserByGuid(Guid guid)
    {
        var user = remoteDatabaseContext.Students.Find(guid);
        if (user == null) return false;
        remoteDatabaseContext.Students.Remove(user);
        return remoteDatabaseContext.SaveChanges() > 0;
    }

    public bool RemoveUsersByGroupId(int groupId)
    {
        var usersToRemove = remoteDatabaseContext.Students
            .Where(user => user.Group.Id == groupId)
            .ToList();
        if (usersToRemove.Any())
        {
            remoteDatabaseContext.Students.RemoveRange(usersToRemove);
            remoteDatabaseContext.SaveChanges();
        }
        return remoteDatabaseContext.SaveChanges() > 0;
    }
}