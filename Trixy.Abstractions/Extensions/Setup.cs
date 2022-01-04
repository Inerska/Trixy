using Microsoft.Extensions.DependencyInjection;

namespace Trixy.Abstractions.Extensions;

public static class Setup
{
    public static IServiceCollection AddTrixyOptions(this IServiceCollection services)
    {
        return services
                .AddTextChannelsOption()
            ;
    }
}