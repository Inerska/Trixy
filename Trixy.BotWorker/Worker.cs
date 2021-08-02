using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Remora.Discord.Gateway;

namespace Trixy.BotWorker
{
    public sealed class Worker
        : BackgroundService
    {
        public Worker(
            ILogger<Worker> logger,
            DiscordGatewayClient discordGatewayClient)
        {
            _logger = logger;
            _discordGatewayClient = discordGatewayClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var result = await _discordGatewayClient.RunAsync(stoppingToken);
            if (!result.IsSuccess)
                throw new Exception(result.Error?.Message, result.Error as Exception);

            _logger.LogInformation("Trixy is ready to serve");
            _logger.LogInformation(DateTime.Now.ToString(CultureInfo.CurrentCulture));
        }

        private readonly ILogger<Worker> _logger;
        private readonly DiscordGatewayClient _discordGatewayClient;
    }
}
