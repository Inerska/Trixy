using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trixy.Abstractions.Extensions;
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
                .ConfigureServices((_, services) =>
                    services
                        .AddHostedService<Worker>()
                        .AddTrixyBot()
                        .AddTrixyOptions()
                        .BuildServiceProvider());
        }
    }
}