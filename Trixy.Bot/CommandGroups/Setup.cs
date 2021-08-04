using Microsoft.Extensions.DependencyInjection;
using Remora.Commands.Extensions;

namespace Trixy.Bot.CommandGroups
{
    public static class Setup
    {
        public static IServiceCollection AddTrixyCommands(this IServiceCollection services)
            => services
                .AddCommandGroup<HelloWorldCommandGroup>()
               .AddCommandGroup<SocialCommandGroup>()
            ;
    }
}
