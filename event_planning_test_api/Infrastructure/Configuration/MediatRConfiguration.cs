using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class MediatRConfiguration
{
    public static IServiceCollection ConfigureMediatR(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddMediatRCommands();

        return services;
    }
}
