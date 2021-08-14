using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.API.Objects;
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

        private readonly IDiscordRestChannelAPI _discordRestChannelApi;

        public ModerationCommandGroup(
            InteractionContext interactionContext,
            IDiscordRestWebhookAPI discordRestWebhookApi,
            IDiscordRestGuildAPI discordRestGuildApi, 
            IDiscordRestUserAPI discordRestUserApi, 
            IDiscordRestChannelAPI discordRestChannelApi)
        {
            _interactionContext = interactionContext;
            _discordRestWebhookApi = discordRestWebhookApi;
            _discordRestGuildApi = discordRestGuildApi;
            _discordRestUserApi = discordRestUserApi;
            _discordRestChannelApi = discordRestChannelApi;
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

            await SendSingleMessageModerationEmbedAsync(message, reason, true, target);

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

            await SendSingleMessageModerationEmbedAsync(message, reason, true, target);

            var result = await _discordRestGuildApi.RemoveGuildMemberAsync(_interactionContext.GuildID.Value, target.ID,
                reason ?? string.Empty);
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        [Command("say")]
        [RequireUserGuildPermission(DiscordPermission.PrioritySpeaker)]
        [Description("Make the bot speaks whatever you want.")]
        public async Task<IResult> ModerationSayCommandAsync([Description("The message that the bot will say.")] string message)
        {
            await SendSingleMessageModerationEmbedAsync(message);

            return Result.FromSuccess();
        }

        private async Task SendSingleMessageModerationEmbedAsync(
            string message,
            string? reason = null,
            bool hasPrivateNotification = false,
            IUser? target = null)
        {
            var embed = TemplateEmbed.GetSingleMessageEmbed(message);

            if (hasPrivateNotification) await SendPrivateUserNotificationAsnyc(target!, embed, reason);
            await MessageHelper.CreateFollowupMessageHelperAsync
            (
                _discordRestWebhookApi,
                _interactionContext,
                embed,
                CancellationToken
            );
        }

        private async Task<IResult> SendPrivateUserNotificationAsnyc(
            IUser target,
            Embed embed,
            string? reason = null)
        {
            var privateUserChannel = await _discordRestUserApi.CreateDMAsync
                (
                    target.ID,
                    CancellationToken
                );

            var guild = _discordRestGuildApi.GetGuildAsync(_interactionContext.GuildID.Value);
            var guildName = guild.Result.Entity?.Name;
            
            var notificationMessageBuilder = new StringBuilder();
            notificationMessageBuilder
                .AppendLine($"You've been kicked / banned from {SurroundWithAsterisks(guildName)} !")
                .AppendLine($"{SurroundWithAsterisks("Reason :")} {reason ?? "no reason"}")
                .AppendLine("───\n")
                .AppendLine("Use this time to repent yourself and comeback again if you can, otherwise, farewells.")
                .AppendLine("— Trixy.");
            
            var result = await _discordRestChannelApi.CreateMessageAsync
                (
                    privateUserChannel.Entity!.ID,
                    embeds: new []{ 
                        embed with
                    {
                        Description = notificationMessageBuilder.ToString()
                    }}
                );
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}