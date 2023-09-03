using event_planning_test_api.Data.Entities;

namespace event_planning_test_api.Domain.Interfaces;

public interface ICurrentUser
{
    Task<UserEntity> GetCurrentUser();
}
