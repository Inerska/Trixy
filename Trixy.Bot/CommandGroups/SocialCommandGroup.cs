using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;

namespace Trixy.Bot.Commands
{
    public class SocialCommands
        : CommandGroup
    {
        public SocialCommands(
            IDiscordRestChannelAPI channelApi,
            ICommandContext context)
        {
            _channelApi = channelApi;
            _context = context;
        }

        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly ICommandContext _context;
    }
}
