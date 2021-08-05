using Microsoft.Extensions.DependencyInjection;
using Remora.Commands.Extensions;

namespace Trixy.Bot.CommandGroups
{
    internal static class Setup
    {
        internal static IServiceCollection AddTrixyCommands(this IServiceCollection services)
            => services
                .AddCommandGroup<MiscellaneousCommandGroup>()
               .AddCommandGroup<SocialCommandGroup>()
            ;
    }
}
