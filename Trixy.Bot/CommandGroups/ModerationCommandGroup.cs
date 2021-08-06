using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;

namespace Trixy.Bot.CommandGroups
{
    public class ModerationCommandGroup
        : CommandGroup
    {
        public ModerationCommandGroup(
            InteractionContext interactionContext,
            IDiscordRestWebhookAPI discordRestWebhookApi)
        {
            _interactionContext = interactionContext;
            _discordRestWebhookApi = discordRestWebhookApi;
        }

        private readonly InteractionContext _interactionContext;
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;
    }
}
