using System.Text;
using event_planning_test_api.Data.Entities;
using event_planning_test_api.Data.Options;
using event_planning_test_api.Domain.Exceptions;
using event_planning_test_api.Infrastructure.Data;
using Infrastructure.ServiceExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

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
        services.AddAuthentication(x => {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option => {
            var jwtOptions = services.BuildServiceProvider()
                .GetOptions<JwtOptions>();
            var Key = Encoding.UTF8.GetBytes(jwtOptions.Key);
            option.SaveToken = true;
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false, // on production make it true
                ValidateAudience = false, // on production make it true
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Key),
                ClockSkew = TimeSpan.Zero
            };
            option.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context => {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                    }

                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    throw new UnauthorizedException("Неверна попытка");
                },
                OnMessageReceived = context =>
                {
                    string BearerPrefix = "Bearer ";
                    if (context.Request.Headers.TryGetValue("Authorization", out StringValues headerValue))
                    {
                        string token = headerValue;
                        if (!string.IsNullOrEmpty(token) && token.StartsWith(BearerPrefix))
                        {
                            token = token.Substring(BearerPrefix.Length);
                        }

                        context.HttpContext.Items.Add("token", token);
                    }

                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }
}
