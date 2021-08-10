using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Remora.Commands.Extensions;

namespace Trixy.Bot.CommandGroups
{
    internal static class Setup
    {
        internal static IServiceCollection AddTrixyCommands(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .AddCommandGroup<MiscellaneousCommandGroup>()
                .AddCommandGroup<SocialCommandGroup>()
                .AddCommandGroup<ModerationCommandGroup>()
                .AddCommandGroup<ReportCommandGroup>()
                .AddCommandGroup<GeneratorCommandGroup>();
        }
    }
}