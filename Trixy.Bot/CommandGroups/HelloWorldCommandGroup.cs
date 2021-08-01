using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using System.Threading.Tasks;

namespace Trixy.Bot.Modules
{
    public class HelloWorldCommandGroup
        : CommandGroup
    {
        public HelloWorldCommandGroup(
            IDiscordRestChannelAPI channelApi,
            ICommandContext context)
        {
            _channelApi = channelApi;
            _context = context;
        }

        [Command("hw")]
        public async Task<IResult> HelloWorldAsync()
        {
            return await _channelApi.CreateMessageAsync(_context.ChannelID, "Hello World!");
        }

        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly ICommandContext _context;
    }

}
