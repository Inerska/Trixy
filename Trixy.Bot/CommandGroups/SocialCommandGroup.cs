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

        [Command("slap")]
        public async Task<IResult> SlapCommandAsync(IUser target)
        {
            await _channelApi.DeleteMessageAsync(_context.ChannelID, _messageContext.MessageID);

            Embed embed = await TemplateEmbed.GetSocialEmbed($"**{_context.User.Username}** slaps **{target.Username}**", SafeForWork.SLAP);

            return await _channelApi.CreateMessageAsync(_context.ChannelID, embeds: new[] { embed });
        }

        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly ICommandContext _context;
        private readonly MessageContext _messageContext;
    }
}
