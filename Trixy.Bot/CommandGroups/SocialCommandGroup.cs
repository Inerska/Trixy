using System.ComponentModel;
using System.Threading.Tasks;
using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using Trixy.Bot.Helpers;
using static Trixy.Bot.Helpers.SocialTheme;
using static Trixy.Bot.Helpers.DiscordFormatter;

namespace Trixy.Bot.CommandGroups
{
    internal class SocialCommandGroup
        : CommandGroup
    {

        public SocialCommandGroup(
            IDiscordRestChannelAPI channelApi,
            ICommandContext context,
            MessageContext messageContext,
            IDiscordRestWebhookAPI discordRestWebhookApi,
            InteractionContext interactionContext)
        {
            _channelApi = channelApi;
            _context = context;
            _messageContext = messageContext;
            _discordRestWebhookApi = discordRestWebhookApi;
            _interactionContext = interactionContext;
        }
        #region CommandsGroups
        [Command("wave")]
        [Description("Wave someone")]
        public async Task<IResult> WaveCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.WAVE, target);
        }

        [Command("dance")]
        [Description("Just dance with style")]
        public async Task<IResult> DanceCommandAsync()
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.DANCE);
        }

        [Command("poke")]
        [Description("Poke poke someone")]
        public async Task<IResult> PokeCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.POKE, target);
        }

        [Command("wink")]
        [Description("Wave someone ;)")]
        public async Task<IResult> WinkCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.WINK, target);
        }

        [Command("kick")]
        [Description("Kick someone")]
        public async Task<IResult> KickCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.KICK, target);
        }

        [Command("kill")]
        [Description("Kill someone")]
        public async Task<IResult> KillCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.KILL, target);
        }

        [Command("bite")]
        [Description("Bite someone")]
        public async Task<IResult> BiteCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.BITE, target);
        }

        [Command("nom")]
        [Description("Chew someone")]
        public async Task<IResult> NomCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.NOM, target);
        }

        [Command("highfive")]
        [Description("Highfive someone")]
        public async Task<IResult> HighFiveCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.HIGHFIVE, target);
        }

        [Command("smile")]
        [Description("Smile :)")]
        public async Task<IResult> SmileCommandAsync()
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.SMILE);
        }

        [Command("blush")]
        [Description("Blush >//<")]
        public async Task<IResult> BlushCommandAsync()
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.BLUSH);
        }

        [Command("smug")]
        [Description("Smug :')")]
        public async Task<IResult> SmugCommandAsync()
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.SMUG);
        }

        [Command("pat", "patpat")]
        [Description("Patpat someone")]
        public async Task<IResult> PatCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.PAT, target);
        }

        [Command("lick")]
        [Description("Lick someone")]
        public async Task<IResult> LickCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.LICK, target);
        }

        [Command("kiss")]
        [Description("Kiss someone :*")]
        public async Task<IResult> KissCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.KISS, target);
        }

        [Command("hug")]
        [Description("Highfive someone")]
        public async Task<IResult> HugCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.HUG, target);
        }

        [Command("cuddle")]
        [Description("Cuddle someone")]
        public async Task<IResult> CuddleCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.CUDDLE, target);
        }

        [Command("bully")]
        [Description("Bully someone :@")]
        public async Task<IResult> BullyCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.BULLY, target);
        }

        [Command("slap")]
        [Description("Slap someone")]
        public async Task<IResult> SlapCommandAsync(IUser? target)
        {
            return await SendSafeSocialEmbedAsync(SafeForWork.SLAP, target);
        }
        #endregion

        private async Task<IResult> SendSafeSocialEmbedAsync(SafeForWork sfwSocialTheme, IUser? target = null)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            var header = target is null
                ? $"{SurroundWithAsterisks(_context.User.Username)} {Stringify(sfwSocialTheme)}"
                : $"{SurroundWithAsterisks(_context.User.Username)} {Stringify(sfwSocialTheme)} {SurroundWithAsterisks(target.Username)}";

            var embed = await TemplateEmbed.GetSocialEmbed(header, sfwSocialTheme);

            //var result = await _channelApi.CreateMessageAsync(_context.ChannelID, embeds: new[] { embed });
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

        private async Task<IResult> SendNotSafeSocialEmbedAsync(NotSafeForWork nsfwSocialTheme, IUser? target = null)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            var header = target is null
                ? $"{SurroundWithAsterisks(_context.User.Username)} {Stringify(nsfwSocialTheme)}"
                : $"{SurroundWithAsterisks(_context.User.Username)} {Stringify(nsfwSocialTheme)} {SurroundWithAsterisks(target.Username)}";

            var embed = await TemplateEmbed.GetSocialEmbed(header, nsfwSocialTheme);

            var result = await _channelApi.CreateMessageAsync(_context.ChannelID, embeds: new[] { embed });
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly ICommandContext _context;
        private readonly MessageContext _messageContext;
        private readonly IDiscordRestWebhookAPI _discordRestWebhookApi;
        private readonly InteractionContext _interactionContext;
    }
}