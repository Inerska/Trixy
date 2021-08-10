using System.ComponentModel;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.API.Objects;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;

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