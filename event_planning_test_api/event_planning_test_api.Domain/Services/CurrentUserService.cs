using event_planning_test_api.Data.Entities;
using event_planning_test_api.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace event_planning_test_api.Domain.Services;

public class CurrentUserService : ICurrentUser
{
    private readonly IHttpContextAccessor http;
    private readonly UserManager<UserEntity> userManager;

    public CurrentUserService(
        IHttpContextAccessor http,
        UserManager<UserEntity> userManager)
    {
        this.http = http;
        this.userManager = userManager;
    }

    public async Task<UserEntity> GetCurrentUser()
    {
        var userEmail = http.HttpContext
            .User
            .Identities
            .First()
            .Claims
            .First()
            .Value;

        return await userManager.FindByEmailAsync(userEmail);
    }
}
