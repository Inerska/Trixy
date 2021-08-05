using Microsoft.Extensions.DependencyInjection;
using Remora.Discord.Commands.Extensions;
using Remora.Discord.Commands.Responders;
using Remora.Discord.Gateway.Extensions;
using System;
using Trixy.Bot.CommandGroups;
using Trixy.Bot.Responders;

namespace Trixy.Bot
{
    public static class Setup
    {
        public static IServiceCollection AddTrixyBot(this IServiceCollection services)
            => services
                .AddDiscordGateway(_ => GetSecretToken())
                .AddDiscordCommands(enableSlash: true)
                .AddTrixyCommands()
                .AddTrixyResponders()
            ;

        private static string GetSecretToken()
        {
            var secretToken = Environment.GetEnvironmentVariable("TRIXY_");
            if (secretToken is null)
                throw new ArgumentNullException(nameof(secretToken));

            return secretToken;
        }
    }
}
