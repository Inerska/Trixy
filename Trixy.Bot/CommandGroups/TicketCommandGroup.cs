using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Conditions;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Abstractions;

namespace Trixy.Bot.CommandGroups
{
    internal class TicketCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;
        private readonly InteractionContext _interactionContext;
        private readonly IOptions<DiscordTextChannelsOptions> _options;

        public TicketCommandGroup(
            IDiscordRestWebhookAPI discordRestWebhookApi,
            InteractionContext interactionContext,
            IOptions<DiscordTextChannelsOptions> options)
        {
            _discordRestWebhookApi = discordRestWebhookApi;
            _interactionContext = interactionContext;
            _options = options;
        }

        [Command("create-ticket")]
        [RequireUserGuildPermission(DiscordPermission.ManageChannels)]
        public async Task<IResult> CreateTicketCommandAsync()
        {
            throw new NotImplementedException();
        }
    }
}