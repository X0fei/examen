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
        throw new NotImplementedException();
    }
}