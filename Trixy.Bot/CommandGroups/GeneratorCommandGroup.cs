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

namespace Trixy.Bot.CommandGroups;

internal class GeneratorCommandGroup
    : CommandGroup
{
    private readonly IDiscordRestInteractionAPI _discordRestInteractionApi;
    private readonly InteractionContext _interactionContext;

    public GeneratorCommandGroup(
        InteractionContext interactionContext,
        IDiscordRestInteractionAPI discordRestInteractionApi)
    {
        _interactionContext = interactionContext;
        _discordRestInteractionApi = discordRestInteractionApi;
    }

    [Command("avatar")]
    [Description("Posts your avatar, or the user's avatar.")]
    public async Task<IResult> GeneratorAvatarCommandAsync(
        [Description("(Mandatory) The user to get the avatar from.")]
        IUser? target = null)
    {
        var userResultAvatarUrl = CDN.GetUserAvatarUrl(target ?? _interactionContext.User);

        var formattedMessage = target is null
            ? $"{_interactionContext.User.ID.Mention()} | Here's your marvelous avatar...\n{userResultAvatarUrl.Entity.AbsoluteUri}"
            : $"{_interactionContext.User.ID.Mention()} | Here's the beautiful avatar of {DiscordFormatter.SurroundWithAsterisks(target.Username)}...\n{userResultAvatarUrl.Entity.AbsoluteUri}";

        var result = await MessageHelper.CreateFollowupMessageHelperAsync
        (
            _discordRestInteractionApi,
            _interactionContext,
            formattedMessage,
            CancellationToken
        );
        return result.IsSuccess
            ? Result.FromSuccess()
            : Result.FromError(result.Error);
    }
}