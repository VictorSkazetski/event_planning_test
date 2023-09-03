using Microsoft.AspNetCore.Identity;

namespace event_planning_test_api.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    public List<UserJoinEventsEntity> UserJoinEvents { get; set; }
}
