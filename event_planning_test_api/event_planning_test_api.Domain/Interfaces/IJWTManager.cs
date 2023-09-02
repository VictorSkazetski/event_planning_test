using event_planning_test_api.Domain.Commands;

namespace event_planning_test_api.Domain.Interfaces;

public interface IJWTManager
{
    Task<UserTokenData> GenerateToken(string userEmail);
}
