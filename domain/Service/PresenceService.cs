using data.DAO;
using data.Repository;
using domain.Entity;
using domain.Requests;

namespace domain.Service;

public class PresenceService(IPresenceRepository repository, ITypeAttendanceRepository attendanceRepository): IPresenceUseCase
{
    public IEnumerable<Presence> GetPresences()
    {
        throw new NotImplementedException();

    }

    public IEnumerable<Presence> GetPresencesBetweenDateRange(DateOnly startDate, DateOnly endDate)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Presence> GetPresencesByGroup(int groupId)
    {
        throw new NotImplementedException();

    }

    public bool UpdatePresence(TypeAttendanceUpdateRequest request)
    {
        var presenceDao = repository
            .GetAllPresences()
            .First(it =>
                it.StudentGuid == request.StudentGuid &&
                it.Date == request.Date &&
                it.LessonNumber == request.LessonNumber &&
                it.SubjectId == request.SubjectId
            );
        var attendanceDao = attendanceRepository.GetAttendanceTypes().First(it => it.Id == request.NewTypeAttendanceId);
        return repository.UpdatePresenceAttendance(presenceDao, attendanceDao);
    }

  

}