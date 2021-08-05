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
                ? $"**{_context.User.Username}** {sfwSocialTheme.ToString().ToLower()}s"
                : $"**{_context.User.Username}** {sfwSocialTheme.ToString().ToLower()}s **{target?.Username}**";

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
                ? $"**{_context.User.Username}** {nsfwSocialTheme.ToString().ToLower()}s"
                : $"**{_context.User.Username}** {nsfwSocialTheme.ToString().ToLower()}s **{target?.Username}**";

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
