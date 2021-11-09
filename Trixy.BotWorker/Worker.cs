using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Remora.Discord.Commands.Services;
using Remora.Discord.Gateway;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Trixy.BotWorker
{
    public sealed class Worker
        : BackgroundService
    {
        private readonly TrixyDbContext _trixyDbContext;
        private readonly DiscordGatewayClient _discordGatewayClient;
        private readonly ILogger<Worker> _logger;
        private readonly SlashService _slashService;

        public Worker(
            TrixyDbContext trixyDbContext,
            ILogger<Worker> logger,
            DiscordGatewayClient discordGatewayClient,
            SlashService slashService)
        {
            _trixyDbContext = trixyDbContext;
            _logger = logger;
            _discordGatewayClient = discordGatewayClient;
            _slashService = slashService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var slashSupported = _slashService.SupportsSlashCommands();
            if (!slashSupported.IsSuccess)
            {
                _logger.LogWarning
                (
                    "Cannot support slash commands :("
                );

                throw new Exception(slashSupported.Error?.Message, slashSupported.Error as Exception);
            }

            var result = await _discordGatewayClient.RunAsync(stoppingToken);
            if (!result.IsSuccess)
            {
                _logger.LogCritical
                (
                    "Oops... something went wrong during the connection of the gateway client."
                );

                throw new Exception(result.Error?.Message, result.Error as Exception);
            }
        }
    }
}