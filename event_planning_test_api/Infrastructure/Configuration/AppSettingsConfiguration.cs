using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class AppSettingsConfiguration
{
    public static IHostBuilder ConfigureAppSettings(this IHostBuilder host)
    {
        host.ConfigureAppConfiguration((ctx, builder) =>
        {
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            builder.AddJsonFile("appsettings.json", false, true);
            builder.AddJsonFile($"appsettings.{enviroment}.json", true, true);
            builder.AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true);
            builder.AddEnvironmentVariables();
        });

        return host;
    }
}
