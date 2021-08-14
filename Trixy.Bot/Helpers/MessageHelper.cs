using System.Threading;
using System.Threading.Tasks;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.API.Objects;
using Remora.Discord.Commands.Contexts;
using Remora.Results;

namespace Trixy.Bot.Helpers
{
    internal static class MessageHelper
    {
        internal static async Task<IResult> CreateFollowupMessageHelperAsync(
            IDiscordRestWebhookAPI discordRestWebhookApi,
            InteractionContext interactionContext,
            Embed embed,
            CancellationToken ct)
        {
            var result = await discordRestWebhookApi.CreateFollowupMessageAsync
            (
                interactionContext.ApplicationID,
                interactionContext.Token,
                embeds: new[] { embed },
                ct: ct
            );
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}