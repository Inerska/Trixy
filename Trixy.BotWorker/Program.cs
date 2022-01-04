using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trixy.Abstractions.Extensions;
using Trixy.Bot;
using Trixy.DataAccess;

namespace Trixy.BotWorker;

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
                    .AddDbContext<TrixyDbContext>(
                        options =>
                            options.UseSqlite("Data Source=C:\trixy.db",
                                x => x.MigrationsAssembly("Trixy.DataAccess.Migrations")))
                    .AddTrixyOptions()
                    .BuildServiceProvider());
    }
}