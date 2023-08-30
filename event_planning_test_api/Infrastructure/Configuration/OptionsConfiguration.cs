﻿
using event_planning_test_api.Data.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class OptionsConfiguration
{
    public static IServiceCollection ConfigureOptions(
            this IServiceCollection services,
            ConfigurationManager configurationManager)
    {
        services.Configure<CorsOptions>(
            configurationManager.GetSection("Cors"));

        return services;
    }
}
