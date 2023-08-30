using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.ServiceExtensions;

public static class OptionsServiceExtension
{
    public static TOptions GetOptions<TOptions>(
        this IServiceProvider serviceProvider)
        where TOptions : class
    {
        var options = serviceProvider.GetRequiredService<IOptions<TOptions>>();
        
        return options.Value;
    }
}
