using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.API.Objects;
using Remora.Discord.Commands.Conditions;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.CommandGroups
{
    //TODO: Logging every moderation commands invok.
    internal class ModerationCommandGroup
        : CommandGroup
    {
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;

        private readonly InteractionContext _interactionContext;

        private readonly IDiscordRestGuildAPI _discordRestGuildApi;

        public ModerationCommandGroup(
            InteractionContext interactionContext,
            IDiscordRestWebhookAPI discordRestWebhookApi, 
            IDiscordRestGuildAPI discordRestGuildApi)
        {
            _interactionContext = interactionContext;
            _discordRestWebhookApi = discordRestWebhookApi;
            _discordRestGuildApi = discordRestGuildApi;
        }

        [Command("ban")][RequireUserGuildPermission(DiscordPermission.BanMembers)]
        [Description("Ban the target from your discord server.")]
        public async Task<IResult> BanCommandAsync(
            [Description("The user to ban.")] IUser target,
            [Description("(Mandatory) The reason.")] string? reason = null)
        {
            var embed = TemplateEmbed.GetBanEmbed(target);

            await _discordRestWebhookApi.CreateFollowupMessageAsync
            (
                _interactionContext.ApplicationID,
                _interactionContext.Token,
                embeds: new[] { embed },
                ct: CancellationToken
            );

            var result = await _discordRestGuildApi.CreateGuildBanAsync(_interactionContext.GuildID.Value, target.ID,
                reason: reason ?? string.Empty);
            
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }
    }
}