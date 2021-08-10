using System.ComponentModel;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.CommandGroups
{
    public class MiscellaneousCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestUserAPI _discordRestUserApi;

        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;
        private readonly InteractionContext _interactionContext;

        public MiscellaneousCommandGroup(
            IDiscordRestWebhookAPI discordRestWebhookApi,
            InteractionContext interactionContext,
            IDiscordRestUserAPI discordRestUserApi)
        {
            _discordRestWebhookApi = discordRestWebhookApi;
            _interactionContext = interactionContext;
            _discordRestUserApi = discordRestUserApi;
        }

        [Command("info", "about", "bot", "trixy")]
        [Description("Get some information about me.")]
        public async Task<IResult> AboutMeCommandAsync()
        {
            var userResult = await _discordRestUserApi.GetCurrentUserAsync();
            var avatarUrlResult = CDN.GetUserAvatarUrl(userResult.Entity!);
            var embed = TemplateEmbed.GetAboutMeEmbed(avatarUrlResult.Entity?.ToString(), userResult.Entity!.ID);

            var result = await _discordRestWebhookApi.CreateFollowupMessageAsync
            (
                _interactionContext.ApplicationID,
                _interactionContext.Token,
                embeds: new[] { embed },
                ct: CancellationToken
            );
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}