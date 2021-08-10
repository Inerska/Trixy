using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;

namespace Trixy.Bot.CommandGroups
{
    public class ModerationCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;

        private readonly InteractionContext _interactionContext;

        public ModerationCommandGroup(
            InteractionContext interactionContext,
            IDiscordRestWebhookAPI discordRestWebhookApi)
        {
            _interactionContext = interactionContext;
            _discordRestWebhookApi = discordRestWebhookApi;
        }
    }
}