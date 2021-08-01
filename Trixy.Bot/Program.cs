using Microsoft.Extensions.DependencyInjection;

using Remora.Discord.Gateway;
using Remora.Discord.Gateway.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Trixy.Bot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cancellationSource = new();

            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                eventArgs.Cancel = true;
                cancellationSource.Cancel();
            };

            string? botToken = Environment.GetEnvironmentVariable("TRIXYS_");

            if (botToken is null)
            {
                throw new ArgumentNullException(nameof(botToken));
            }

            var services = new ServiceCollection()
                .AddDiscordGateway(_ => botToken)
                .BuildServiceProvider();

            var gatewayClient = services.GetRequiredService<DiscordGatewayClient>();

            var runResult = await gatewayClient.RunAsync(cancellationSource.Token);
        }
    }
}
