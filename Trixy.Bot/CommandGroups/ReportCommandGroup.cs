using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;

namespace Trixy.Bot.CommandGroups
{
    internal class ReportCommandGroup
        : CommandGroup
    {
        private readonly IConfiguration _configuration;
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;
        private readonly InteractionContext _interactionContext;

        public ReportCommandGroup(
            IConfiguration configuration,
            IDiscordRestWebhookAPI discordRestWebhookApi,
            InteractionContext interactionContext)
        {
            _configuration = configuration;
            _discordRestWebhookApi = discordRestWebhookApi;
            _interactionContext = interactionContext;
        }

        [Command("test")]
        public async Task<IResult> TestCommand()
        {
            var result = await _discordRestWebhookApi.CreateFollowupMessageAsync
            (
                _interactionContext.ApplicationID,
                _interactionContext.Token,
                /*_configuration.Get<string>("TextChannels:ReportTextChannelId") 
                ?? "Cannot find anything in your specified configuration path.",*/
                ct: CancellationToken
            );

            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}