using System.Threading;
using System.Threading.Tasks;
using Remora.Discord.API;
using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Gateway.Responders;
using Remora.Results;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.Responders
{
    public class MentionSelfResponder
        : IResponder<IMessageCreate>
    {
        private readonly IDiscordRestChannelAPI _discordRestChannelApi;
        private readonly IDiscordRestUserAPI _discordRestUserApi;

        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;

        public MentionSelfResponder(
            IDiscordRestUserAPI discordRestUserApi,
            IDiscordRestWebhookAPI discordRestWebhookApi,
            IDiscordRestChannelAPI discordRestChannelApi)
        {
            _discordRestUserApi = discordRestUserApi;
            _discordRestWebhookApi = discordRestWebhookApi;
            _discordRestChannelApi = discordRestChannelApi;
        }

        public async Task<Result> RespondAsync(IMessageCreate gatewayEvent, CancellationToken ct = default)
        {
            var userResult = await _discordRestUserApi.GetCurrentUserAsync(ct);
            var avatarUrlResult = CDN.GetUserAvatarUrl(userResult.Entity);
            var embed = TemplateEmbed.GetAboutMeEmbed(avatarUrlResult.Entity?.ToString(), userResult.Entity.ID);

            var botMention = userResult.Entity.ID.Mention();

            if (gatewayEvent.Content != botMention)
                return Result.FromSuccess();

            await _discordRestChannelApi.DeleteMessageAsync(gatewayEvent.ChannelID, gatewayEvent.ID, ct: ct);

            var result = await _discordRestChannelApi.CreateMessageAsync(
                gatewayEvent.ChannelID,
                embeds: new[] { embed }, ct: ct);

            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}