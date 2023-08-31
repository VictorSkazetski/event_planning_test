using event_planning_test_api.Data.Options;
using Infrastructure.ServiceExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DbContext = event_planning_test_api.Infrastructure.Data.DbContext;

namespace event_planning_test_api.Infrastructure.Configuration;

public static class DbConfiguration
{
    public static IServiceCollection ConfigureDbContext(
    this IServiceCollection services)
    {
        var connectionString = services.BuildServiceProvider()
                .GetOptions<DbOptions>();
        services.AddDbContext<DbContext>(options =>
            options.UseSqlServer(connectionString.DbConnection));

        return services;
    }
}
