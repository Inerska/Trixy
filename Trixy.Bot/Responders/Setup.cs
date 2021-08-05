using Microsoft.Extensions.DependencyInjection;
using Remora.Discord.Gateway.Extensions;

namespace Trixy.Bot.Responders
{
    public static class Setup
    {
        public static IServiceCollection AddTrixyResponders(this IServiceCollection services)
            => services
                .AddResponder<ReadyResponder>(Remora.Discord.Gateway.Responders.ResponderGroup.Early)
            ;
    }
}
