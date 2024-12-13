using domain.Entity;

namespace domain.Service;

public interface IGroupUseCase
{
    IEnumerable<Student> GetStudentsByGroupId(int groupId);
    bool RemoveStudentsByGroupId(int groupId);
    bool RemoveStudentById(Guid studentGuid);
    IEnumerable<Group> GetGroups();
}