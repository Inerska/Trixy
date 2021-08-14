using System.ComponentModel;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.CommandGroups
{
    internal class GeneratorCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;

        private readonly InteractionContext _interactionContext;

        public GeneratorCommandGroup(
            InteractionContext interactionContext,
            IDiscordRestWebhookAPI discordRestWebhookApi)
        {
            _interactionContext = interactionContext;
            _discordRestWebhookApi = discordRestWebhookApi;
        }

        [Command("avatar")]
        [Description("Posts your avatar, or the user's avatar.")]
        public async Task<IResult> AvatarGeneratorCommandAsync(
            [Description("(Mandatory) The user to get the avatar from.")] IUser? target = null)
        {
            var userResultAvatarUrl = target is null 
                ? CDN.GetUserAvatarUrl(_interactionContext.User)
                : CDN.GetUserAvatarUrl(target);

            var formattedMessage = target is null
                ? $"{_interactionContext.User.ID.Mention()} | Here's your marvelous avatar...\n{userResultAvatarUrl.Entity?.AbsoluteUri}"
                : $"{_interactionContext.User.ID.Mention()} | Here's the beautiful avatar of {DiscordFormatter.SurroundWithAsterisks(target.Username)}...\n{userResultAvatarUrl.Entity?.AbsoluteUri}"; 

            var result = await _discordRestWebhookApi.CreateFollowupMessageAsync
            (
                _interactionContext.ApplicationID,
                _interactionContext.Token,
                formattedMessage,
                ct: CancellationToken
            );
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}