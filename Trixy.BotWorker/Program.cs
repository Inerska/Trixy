using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Trixy.Bot;

namespace Trixy.BotWorker
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) => services
                    .AddLogging(c => c.AddConsole())
                    .AddHostedService<Worker>()
                    .AddTrixyBot()
                    .BuildServiceProvider());
    }
}
