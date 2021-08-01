using Microsoft.Extensions.DependencyInjection;
using Remora.Commands.Extensions;
using Trixy.Bot.Modules;

namespace Trixy.Bot.Commands
{
    public static class Setup
    {
        public static IServiceCollection AddTrixyCommands(this IServiceCollection services)
            => services
                .AddCommandGroup<SocialCommandGroup>()
                .AddCommandGroup<HelloWorldCommandGroup>()
            ;
    }
}
