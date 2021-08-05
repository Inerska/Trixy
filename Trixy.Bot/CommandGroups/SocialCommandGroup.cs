using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using System.Threading.Tasks;
using Remora.Discord.API.Abstractions.Objects;
using Trixy.Bot.Helpers;
using static Trixy.Bot.Helpers.SocialTheme;

namespace Trixy.Bot.CommandGroups
{
    internal class SocialCommandGroup
        : CommandGroup
    {
        public SocialCommandGroup(
            IDiscordRestChannelAPI channelApi,
            ICommandContext context,
            MessageContext messageContext)
        {
            _channelApi = channelApi;
            _context = context;
            _messageContext = messageContext;
        }

        [Command("wave")]
        public async Task<IResult> WaveCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.WAVE, target);

        [Command("dance")]
        public async Task<IResult> DanceCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.DANCE, null);

        [Command("poke")]
        public async Task<IResult> PokeCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.POKE, target);

        [Command("wink")]
        public async Task<IResult> WinkNullArgCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.WINK, null);

        [Command("wink")]
        public async Task<IResult> WinkCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.WINK, target);

        [Command("kick")]
        public async Task<IResult> KickCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.KICK, target);

        [Command("kill")]
        public async Task<IResult> KillCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.KILL, target);

        [Command("bite")]
        public async Task<IResult> BiteCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.BITE, target);

        [Command("nom")]
        public async Task<IResult> NomCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.NOM, target);

        [Command("highfive")]
        public async Task<IResult> HighFiveCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.HIGHFIVE, target);

        [Command("smile")]
        public async Task<IResult> SmileCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.SMILE, null);

        [Command("blush")]
        public async Task<IResult> BlushCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.BLUSH, null);

        [Command("smug")]
        public async Task<IResult> SmugCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.SMUG, null);

        [Command("pat", "patpat")]
        public async Task<IResult> PatCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.PAT, target);

        [Command("lick")]
        public async Task<IResult> LickCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.LICK, target);

        [Command("kiss")]
        public async Task<IResult> KissCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.KISS, target);

        [Command("hug")]
        public async Task<IResult> HugCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.HUG, target);

        [Command("cry")]
        public async Task<IResult> CryCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.CRY, null);

        [Command("cuddle")]
        public async Task<IResult> CuddleCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.CUDDLE, target);

        [Command("bully")]
        public async Task<IResult> BullyCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.BULLY, target);

        [Command("slap")]
        public async Task<IResult> SlapCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.SLAP, target);

        private async Task<IResult> SendSafeSocialEmbedAsync(SafeForWork sfwSocialTheme, IUser? target)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            var header = target is null
                ? $"**{_context.User.Username}** {Stringify(sfwSocialTheme)}"
                : $"**{_context.User.Username}** {Stringify(sfwSocialTheme)} **{target?.Username}**";

            var embed = await TemplateEmbed.GetSocialEmbed(header, sfwSocialTheme);

            var result = await _channelApi.CreateMessageAsync(_context.ChannelID, embeds: new[] { embed });
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        private async Task<IResult> SendNotSafeSocialEmbedAsync(NotSafeForWork nsfwSocialTheme, IUser? target)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            var header = target is null
                ? $"**{_context.User.Username}** {Stringify(nsfwSocialTheme)}"
                : $"**{_context.User.Username}** {Stringify(nsfwSocialTheme)} **{target?.Username}**";

            var embed = await TemplateEmbed.GetSocialEmbed(header, nsfwSocialTheme);

            var result = await _channelApi.CreateMessageAsync(_context.ChannelID, embeds: new[] { embed });
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly ICommandContext _context;
        private readonly MessageContext _messageContext;
    }
}
