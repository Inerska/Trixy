using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Remora.Discord.Commands.Services;
using Remora.Discord.Gateway;

namespace Trixy.BotWorker
{
    public sealed class Worker
        : BackgroundService
    {
        public Worker(
            ILogger<Worker> logger,
            DiscordGatewayClient discordGatewayClient,
            SlashService slashService)
        {
            _logger = logger;
            _discordGatewayClient = discordGatewayClient;
            _slashService = slashService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var slashSupported = _slashService.SupportsSlashCommands();
            if (!slashSupported.IsSuccess)
            {
                _logger.LogCritical
                    (
                        "The registered commands don't support slash commands :(",
                        slashSupported.Error.Message
                    );

                throw new Exception(slashSupported.Error?.Message, slashSupported.Error as Exception);
            }

            var result = await _discordGatewayClient.RunAsync(stoppingToken);
            if (!result.IsSuccess)
            {
                _logger.LogCritical
                    (
                        "Oops... something went wrong during the connection of the gateway client.",
                        result.Error.Message
                    );

                throw new Exception(result.Error?.Message, result.Error as Exception);
            }
        }

        private readonly ILogger<Worker> _logger;
        private readonly DiscordGatewayClient _discordGatewayClient;
        private readonly SlashService _slashService;
    }
}
