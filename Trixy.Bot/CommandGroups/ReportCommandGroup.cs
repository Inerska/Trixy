using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Abstractions;

namespace Trixy.Bot.CommandGroups
{
    internal class ReportCommandGroup
        : CommandGroup
    {
        private readonly IOptions<DiscordTextChannelsOptions> _options;
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;
        private readonly InteractionContext _interactionContext;

        public ReportCommandGroup(
            IDiscordRestWebhookAPI discordRestWebhookApi,
            InteractionContext interactionContext, 
            IOptions<DiscordTextChannelsOptions> options)
        {
            _discordRestWebhookApi = discordRestWebhookApi;
            _interactionContext = interactionContext;
            _options = options;
        }

        [Command("test")]
        public async Task<IResult> TestCommand()
        {
            var result = await _discordRestWebhookApi.CreateFollowupMessageAsync
            (
                _interactionContext.ApplicationID,
                _interactionContext.Token,
                _options.Value.ReportTextChannelId ?? "null",
                ct: CancellationToken
            );
            
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}