using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;

namespace Trixy.Bot.CommandGroups
{
    public class GeneratorCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;

        private readonly InteractionContext _interactionContext;

        public GeneratorCommandGroup(
            InteractionContext interactionContext,
            IDiscordRestWebhookAPI discordRestWebhookApi)
        {
            _interactionContext = interactionContext;
            _discordRestWebhookApi = discordRestWebhookApi;
        }
    }
}