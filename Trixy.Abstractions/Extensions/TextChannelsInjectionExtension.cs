using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Trixy.Abstractions.Extensions
{
    public static class TextChannelsInjectionExtension
    {
        public static IServiceCollection AddTextChannelsOption(this IServiceCollection services)
        {
            services
                .AddOptions<DiscordTextChannelsOptions>()
                .Configure<IConfiguration>((options, configuration) =>
                    configuration.Bind(options.ConfigurationModuleName, options));

            return services;
        }

        public static IServiceCollection AddTextChannelsOption(this IServiceCollection services,
            Action<DiscordTextChannelsOptions> action)
        {
            return services
                .AddTextChannelsOption()
                .Configure(action);
        }
    }
}