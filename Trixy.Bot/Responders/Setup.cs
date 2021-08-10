using Microsoft.Extensions.DependencyInjection;
using Remora.Discord.Gateway.Extensions;
using Remora.Discord.Gateway.Responders;

namespace Trixy.Bot.Responders
{
    internal static class Setup
    {
        internal static IServiceCollection AddTrixyResponders(this IServiceCollection services)
        {
            return services
                .AddResponder<ReadyResponder>(ResponderGroup.Early)
                .AddResponder<MentionSelfResponder>();
        }
    }
}