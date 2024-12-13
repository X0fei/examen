using domain.Entity;
using domain.Requests;

namespace domain.Service;

public interface IPresenceUseCase
{
    public IEnumerable<Presence>? GetPresences();
    public IEnumerable<Presence>? GetPresencesBetweenDateRange(DateOnly startDate, DateOnly endDate);
    public IEnumerable<Presence>? GetPresencesByGroup(int groupId);
    public bool UpdatePresence(TypeAttendanceUpdateRequest request);
    
}