﻿using Microsoft.Extensions.Logging;
using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Gateway.Commands;
using Remora.Discord.API.Objects;
using Remora.Discord.Gateway;
using Remora.Discord.Gateway.Responders;
using Remora.Discord.Gateway.Services;
using Remora.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Trixy.Bot.Responders
{
    public class ReadyResponder
        : IResponder<IReady>
    {
        public ReadyResponder(
            DiscordGatewayClient gatewayClient,
            ILogger<ResponderService> logger)
        {
            _gatewayClient = gatewayClient;
            _logger = logger;
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

        private readonly DiscordGatewayClient _gatewayClient;
        private readonly ILogger<ResponderService> _logger;
    }
}