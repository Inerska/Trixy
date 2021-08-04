using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using System.Threading.Tasks;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Objects;
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

        [Command("cuddle")]
        public async Task<IResult> CuddleCommandAsync(IUser target)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            Embed embed = await TemplateEmbed.GetSocialEmbed($"**{_context.User.Username}** cuddles **{target.Username}**", SafeForWork.CUDDLE);

            var result = await _channelApi.CreateMessageAsync(_context.ChannelID, embeds: new[] { embed });
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        [Command("bully")]
        public async Task<IResult> BullyCommandAsync(IUser target)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            Embed embed = await TemplateEmbed.GetSocialEmbed($"**{_context.User.Username}** bullies **{target.Username}**", SafeForWork.BULLY);

            var result = await _channelApi.CreateMessageAsync(_context.ChannelID, embeds: new[] { embed });
            return result.IsSuccess
                ? Result.FromSuccess()
                : Result.FromError(result.Error);
        }

        [Command("slap")]
        public async Task<IResult> SlapCommandAsync(IUser target)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            Embed embed = await TemplateEmbed.GetSocialEmbed($"**{_context.User.Username}** slaps **{target.Username}**", SafeForWork.SLAP);

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
