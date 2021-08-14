using System.ComponentModel;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Conditions;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;

using static Trixy.Bot.Helpers.DiscordFormatter;

namespace Trixy.Bot.CommandGroups
{
    //TODO: Logging every moderation commands invok.
    internal class ModerationCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;

        private readonly InteractionContext _interactionContext;

        private readonly IDiscordRestGuildAPI _discordRestGuildApi;

        private readonly IDiscordRestUserAPI _discordRestUserApi;

        public ModerationCommandGroup(
            InteractionContext interactionContext,
            IDiscordRestWebhookAPI discordRestWebhookApi,
            IDiscordRestGuildAPI discordRestGuildApi, 
            IDiscordRestUserAPI discordRestUserApi)
        {
            _interactionContext = interactionContext;
            _discordRestWebhookApi = discordRestWebhookApi;
            _discordRestGuildApi = discordRestGuildApi;
            _discordRestUserApi = discordRestUserApi;
        }

        [Command("ban")]
        [RequireUserGuildPermission(DiscordPermission.BanMembers)]
        [Description("Ban the target from your discord server.")]
        public async Task<IResult> ModerationBanCommandAsync(
            [Description("The user to ban.")] IUser target,
            [Description("(Mandatory) The reason.")] string? reason = null)
        {
            var message =
                $"I have banned {SurroundWithAsterisks(target.Username)}, he/she/they won't bother us anymore for a looong time...";

            await SendSingleMessageModerationEmbed(message);

            var result = await _discordRestGuildApi.CreateGuildBanAsync(_interactionContext.GuildID.Value, target.ID,
                reason: reason ?? string.Empty);

            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        [Command("kick")]
        [RequireUserGuildPermission(DiscordPermission.KickMembers)]
        [Description("Kick the target out of your discord server.")]
        public async Task<IResult> ModerationKickCommandAsync(
            [Description("The user to kick.")] IUser target,
            [Description("(Mandatory) The reason.")] string? reason = null)
        {
            var message =
                $"I have kicked {SurroundWithAsterisks(target.Username)} out, hope to not seeing him/her/them for a long time...";

            await SendSingleMessageModerationEmbed(message);

            var result = await _discordRestGuildApi.RemoveGuildMemberAsync(_interactionContext.GuildID.Value, target.ID,
                reason ?? string.Empty);
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        private async Task SendSingleMessageModerationEmbed(string message)
        {
            var embed = TemplateEmbed.GetSingleMessageEmbed(message);
            
            await MessageHelper.CreateFollowupMessageHelperAsync
            (
                _discordRestWebhookApi,
                _interactionContext,
                embed,
                CancellationToken
            );
        }
        
        private async Task Send
    }
}