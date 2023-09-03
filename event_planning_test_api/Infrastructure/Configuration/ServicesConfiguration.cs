using event_planning_test_api.Domain.Interfaces;
using event_planning_test_api.Domain.Middlewares;
using event_planning_test_api.Domain.Services;
using event_planning_test_api.Infrastructure.Data.Repositories.Interfaces;
using event_planning_test_api.Infrastructure.Data.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ConfigureServices(
            this IServiceCollection services)
    {
        services.AddScoped<ExceptionMiddleware>();
        services.AddSingleton((IServiceProvider sp) => CreateMapperConfig());
        services.AddScoped((Func<IServiceProvider, IMapper>)((IServiceProvider sp) =>
            new ServiceMapper(sp, sp.GetRequiredService<TypeAdapterConfig>())));
        services.AddScoped<IRegistrationEmail, RegistrationEmailService>();
        services.AddScoped<IRegistrationEmailMessage, RegistrationEmailMessageService>();
        services.AddScoped(typeof(ICrudBaseRepository<,>), typeof(CrudBaseRepository<,>));
        services.AddScoped<IJWTManager, JWTManagerService>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ICurrentUser, CurrentUserService>();

        return services;
    }

    static TypeAdapterConfig CreateMapperConfig()
    {
        TypeAdapterConfig typeAdapterConfig = new TypeAdapterConfig();
        typeAdapterConfig.ConfigureMapping();

        return typeAdapterConfig;
    }
}
