using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using System.Threading.Tasks;
using Remora.Discord.Core;
using Trixy.Bot.Helpers;

namespace Trixy.Bot.Commands
{
    public class SocialCommandGroup
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
        public async Task<IResult> SlapCommandAsync()
        {
            var gif = await ExternalFetcher.RandomThemeGifFromApi(SocialTheme.SLAP);

            return await _channelApi.CreateMessageAsync(_context.ChannelID, gif);
        }


        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly ICommandContext _context;
    }
}
