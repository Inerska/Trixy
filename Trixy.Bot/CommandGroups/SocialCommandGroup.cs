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
        public async Task<IResult> WaveCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.WAVES, target);

        [Command("dance")]
        public async Task<IResult> DanceCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.DANCES, null);

        [Command("poke")]
        public async Task<IResult> PokeCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.POKES, target);

        [Command("wink")]
        public async Task<IResult> WinkNullArgCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.WINKS, null);

        [Command("wink")]
        public async Task<IResult> WinkCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.WINKS, target);

        [Command("kick")]
        public async Task<IResult> KickCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.KICKS, target);

        [Command("kill")]
        public async Task<IResult> KillCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.KILLS, target);

        [Command("bite")]
        public async Task<IResult> BiteCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.BITES, target);

        [Command("nom")]
        public async Task<IResult> NomCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.NOMS, target);

        [Command("highfive")]
        public async Task<IResult> HighFiveCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.HIGHFIVES, target);

        [Command("smile")]
        public async Task<IResult> SmileCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.SMILES, null);

        [Command("blush")]
        public async Task<IResult> BlushCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.BLUSHES, null);

        [Command("smug")]
        public async Task<IResult> SmugCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.SMUGS, null);

        [Command("pat", "patpat")]
        public async Task<IResult> PatCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.PATS, target);

        [Command("lick")]
        public async Task<IResult> LickCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.LICKS, target);

        [Command("kiss")]
        public async Task<IResult> KissCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.KISSES, target);

        [Command("hug")]
        public async Task<IResult> HugCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.HUGS, target);

        [Command("cry")]
        public async Task<IResult> CryCommandAsync() => await SendSafeSocialEmbedAsync(SafeForWork.CRIES, null);

        [Command("cuddle")]
        public async Task<IResult> CuddleCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.CUDDLES, target);

        [Command("bully")]
        public async Task<IResult> BullyCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.BULLIES, target);

        [Command("slap")]
        public async Task<IResult> SlapCommandAsync(IUser? target) => await SendSafeSocialEmbedAsync(SafeForWork.SLAPS, target);

        private async Task<IResult> SendSafeSocialEmbedAsync(SafeForWork sfwSocialTheme, IUser? target)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            var header = target is null
                ? $"**{_context.User.Username}** {sfwSocialTheme.ToString().ToLower()}"
                : $"**{_context.User.Username}** {sfwSocialTheme.ToString().ToLower()} **{target?.Username}**";

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
                ? $"**{_context.User.Username}** {nsfwSocialTheme.ToString().ToLower()}"
                : $"**{_context.User.Username}** {nsfwSocialTheme.ToString().ToLower()} **{target?.Username}**";

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
