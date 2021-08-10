using System.ComponentModel;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.API.Objects;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.CommandGroups
{
    public class GeneratorCommandGroup
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

        [Command("trigger")]
        [Description("Posts your triggered avatar.")]
        public async Task<IResult> TriggerAvatarCommandAsync()
        {
            var user = _interactionContext.User;
            var userAvatar = CDN.GetUserAvatarUrl(user);
            var embedImage = await ExternalFetcher.GetTriggerAvatarAsEmbedImage(userAvatar.Entity);

            var result = await _discordRestWebhookApi.CreateFollowupMessageAsync
            (
                _interactionContext.ApplicationID,
                _interactionContext.Token,
                embeds: new[] { new Embed(Image: embedImage) },
                ct: CancellationToken
            );

            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}