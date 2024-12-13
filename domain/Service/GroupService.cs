using data.Repository;
using domain.Entity;

namespace domain.Service;

public class GroupService(IGroupRepository groupRepository, IUserRepository userRepository): IGroupUseCase
{
    public IEnumerable<Student> GetStudentsByGroupId(int groupId)
    {
        var group = groupRepository.GetGroupById(groupId);
        if (group == null) throw new Exception($"Group with id {groupId} not found");
        if (group.Students == null) throw new Exception($"Group {groupId} is empty");
        return groupRepository.GetGroupById(groupId).Students.Select(DaoToEntityMapper.StudentDaoToStudent);
    }

    public bool RemoveStudentsByGroupId(int groupId)
    {
        var group = groupRepository.GetGroupById(groupId);
        if (group == null) throw new Exception($"Group with id {groupId} not found");
        return userRepository.RemoveUsersByGroupId(groupId);
    }

    public bool RemoveStudentById(Guid studentGuid)
    {
        if (studentGuid == Guid.Empty) throw new ArgumentException($"Student with id {studentGuid} not found");
        return userRepository.RemoveUserByGuid(studentGuid);
    }

    public IEnumerable<Group> GetGroups()
    {
        return groupRepository.GetGroups().Select(DaoToEntityMapper.GroupDaoToGroup);
    }
}