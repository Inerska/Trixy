using Microsoft.Extensions.DependencyInjection;
using Remora.Discord.Gateway.Extensions;

namespace Trixy.Bot.Responders
{
    internal static class Setup
    {
        internal static IServiceCollection AddTrixyResponders(this IServiceCollection services)
            => services
                .AddResponder<ReadyResponder>(Remora.Discord.Gateway.Responders.ResponderGroup.Early)
                .AddResponder<MentionSelfResponder>()
            ;
    }
}
