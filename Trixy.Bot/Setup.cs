using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Remora.Discord.Commands.Extensions;
using Remora.Discord.Gateway.Extensions;
using Trixy.Bot.CommandGroups;
using Trixy.Bot.Responders;

namespace Trixy.Bot
{
    public static class Setup
    {
        public static IServiceCollection AddTrixyBot(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddDiscordGateway(_ => GetSecretToken())
                .AddDiscordCommands(true)
                .AddTrixyCommands(configuration)
                .AddTrixyResponders();
        }

        private static string GetSecretToken()
        {
            var secretToken = Environment.GetEnvironmentVariable("TRIXY_");
            if (secretToken is null)
                throw new ArgumentNullException(nameof(secretToken));

            return secretToken;
        }
    }
}