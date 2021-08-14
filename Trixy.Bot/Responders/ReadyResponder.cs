using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Gateway.Commands;
using Remora.Discord.API.Objects;
using Remora.Discord.Commands.Services;
using Remora.Discord.Core;
using Remora.Discord.Gateway;
using Remora.Discord.Gateway.Responders;
using Remora.Discord.Gateway.Services;
using Remora.Discord.Rest.API;
using Remora.Results;

namespace Trixy.Bot.Responders
{
    public class ReadyResponder
        : IResponder<IReady>, IResponder<IGuildCreate>
    {
        private readonly DiscordGatewayClient _gatewayClient;
        private readonly ILogger<ResponderService> _logger;
        private readonly SlashService _slashService;

        public ReadyResponder(
            DiscordGatewayClient gatewayClient,
            ILogger<ResponderService> logger,
            SlashService slashService)
        {
            _gatewayClient = gatewayClient;
            _logger = logger;
            _slashService = slashService;
        }

        public async Task<Result> RespondAsync(IGuildCreate gatewayEvent, CancellationToken ct = default)
        {
            _logger.LogInformation("Setting up slash-commands");
            
            var result = await _slashService.UpdateSlashCommandsAsync(gatewayEvent.ID, ct);
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        public Task<Result> RespondAsync(IReady gatewayEvent, CancellationToken ct = default)
        {
            var presenceCommand = new UpdatePresence(ClientStatus.Online, false, null, new IActivity[]
            {
                new Activity("the twinkle twinkle little star", ActivityType.Watching)
            });

            _gatewayClient.SubmitCommandAsync(presenceCommand);
            _logger.LogInformation("Operational !");

            return Task.FromResult(Result.FromSuccess());
        }
    }
}