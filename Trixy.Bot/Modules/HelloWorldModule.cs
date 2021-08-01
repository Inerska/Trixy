using Remora.Commands.Attributes;
using Remora.Commands.Groups;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Results;
using System.Threading.Tasks;

namespace Trixy.Bot.Modules
{
    public class HelloWorldModule : CommandGroup
    {
        private readonly IDiscordRestChannelAPI _channelAPI;
        private readonly ICommandContext _context;

        public HelloWorldModule(IDiscordRestChannelAPI channelAPI, ICommandContext commandContext)
        {
            _channelAPI = channelAPI;
            _context = commandContext;

            System.Console.WriteLine("Loaded");
        }

        [Command("hw")]
        public async Task<IResult> HelloWorldAsync()
        {
            return await _channelAPI.CreateMessageAsync(_context.ChannelID, "Hello World!");
        }
    }

}
