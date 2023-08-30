using event_planning_test_api.Data.Options;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.ServiceExtensions;

namespace Infrastructure.Configuration
{
    public static class CorsConfiguration
    {
        public static string AllowSpecificOrigins => "allowSpecificOrigins";

        public static IServiceCollection ConfigureCors(
            this IServiceCollection services)
        {
            var corsOptions = services.BuildServiceProvider()
                .GetOptions<CorsOptions>();
            services.AddCors(options =>
                options.AddPolicy(AllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins(corsOptions.Hosts)
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                    }));

            return services;
        }
    }
}
