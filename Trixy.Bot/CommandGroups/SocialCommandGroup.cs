using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using System.Threading.Tasks;
using Remora.Discord.API.Abstractions.Objects;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.CommandGroups
{
    internal class SocialCommandGroup
        : CommandGroup
    {
        public SocialCommandGroup(
            IDiscordRestChannelAPI channelApi,
            ICommandContext context)
        {
            _channelApi = channelApi;
            _context = context;
        }

        [Command("slap")]
        public async Task<IResult> SlapCommandAsync(IGuildMember to)
        {
            var gif = await ExternalFetcher.GetRandomThemeGif(SocialTheme.SLAP);

            return await _channelApi.CreateMessageAsync(_context.ChannelID, $"{gif}\n**{_context.User.Username}** slaps **{to.User.Value.Username}** !");
        }
        
        

        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly ICommandContext _context;
    }
}
