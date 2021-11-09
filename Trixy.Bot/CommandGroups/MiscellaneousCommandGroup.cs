using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using System.ComponentModel;
using System.Threading.Tasks;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.CommandGroups
{
    internal class MiscellaneousCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestUserAPI _discordRestUserApi;
        private readonly IDiscordRestInteractionAPI _discordRestInteractionApi;
        private readonly InteractionContext _interactionContext;

        public MiscellaneousCommandGroup(
            IDiscordRestInteractionAPI discordRestInteractionApi,
            InteractionContext interactionContext,
            IDiscordRestUserAPI discordRestUserApi)
        {
            _discordRestInteractionApi = discordRestInteractionApi;
            _interactionContext = interactionContext;
            _discordRestUserApi = discordRestUserApi;
        }

        [Command("info", "about", "bot", "trixy")]
        [Description("Get some information about me.")]
        public async Task<IResult> MiscellaneousAboutCommandAsync()
        {
            var userResult = await _discordRestUserApi.GetCurrentUserAsync();
            var avatarUrlResult = CDN.GetUserAvatarUrl(userResult.Entity!);
            var embed = TemplateEmbed.GetAboutMeEmbed(avatarUrlResult.Entity?.ToString(), userResult.Entity!.ID);

            var result = await MessageHelper.CreateFollowupEmbedMessageHelperAsync
            (
                _discordRestInteractionApi,
                _interactionContext,
                embed,
                CancellationToken
            );
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}