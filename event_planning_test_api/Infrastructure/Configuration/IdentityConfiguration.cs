using event_planning_test_api.Data.Entities;
using event_planning_test_api.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class IdentityConfiguration
{
    public static IServiceCollection ConfigureIdentity(
        this IServiceCollection services)
    {
        services.AddIdentityCore<UserEntity>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
        })
        .AddRoles<RolesEnity>()
        .AddEntityFrameworkStores<DbContext>()
        .AddDefaultTokenProviders();
        services.AddDataProtection();

        return services;
    }
}
