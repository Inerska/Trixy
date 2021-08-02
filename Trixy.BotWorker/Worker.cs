using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Remora.Discord.Gateway;

namespace Trixy.BotWorker
{
    public class Worker
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
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);

                await _discordGatewayClient.RunAsync(stoppingToken);
            }
        }

        private readonly ILogger<Worker> _logger;
        private readonly DiscordGatewayClient _discordGatewayClient;
    }
}
