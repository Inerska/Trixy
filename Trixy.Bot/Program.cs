using Microsoft.Extensions.DependencyInjection;
using Remora.Commands.Extensions;
using Remora.Discord.Commands.Extensions;
using Remora.Discord.Commands.Responders;
using Remora.Discord.Gateway;
using Remora.Discord.Gateway.Extensions;

using System;
using System.Threading;
using System.Threading.Tasks;
using Trixy.Bot.Commands;
using Trixy.Bot.Modules;

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

            string? botToken = Environment.GetEnvironmentVariable("TRIXY_");

            if (botToken is null)
            {
                throw new ArgumentNullException(nameof(botToken));
            }

            var services = new ServiceCollection()
                .AddLogging()
                .AddDiscordGateway(_ => botToken)
                .AddDiscordCommands()
                .Configure<CommandResponderOptions>(options => options.Prefix = "!")
                .AddTrixyCommands()
                .BuildServiceProvider();

            var gatewayClient = services.GetRequiredService<DiscordGatewayClient>();

            var runResult = await gatewayClient.RunAsync(cancellationSource.Token);
        }
    }
}
