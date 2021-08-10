using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Trixy.Bot;

namespace Trixy.BotWorker
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                    ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services
                        .AddLogging(c => c.AddConsole())
                        .AddHostedService<Worker>()
                        .AddTrixyBot(context.Configuration)));
        }
    }
}