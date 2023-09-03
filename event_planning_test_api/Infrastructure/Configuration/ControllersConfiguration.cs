using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class ControllersConfiguration
{
    public static IServiceCollection ConfigureControllers(
            this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.OutputFormatters.RemoveType<StringOutputFormatter>();
        });

        return services;
    }
}
