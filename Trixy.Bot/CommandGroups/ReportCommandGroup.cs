using Remora.Commands.Groups;
using Remora.Discord.Rest.API;

namespace Trixy.Bot.CommandGroups
{
    public class ReportCommandGroup
        : CommandGroup
    {
        private readonly DiscordRestChannelAPI _discordRestChannelApi;
        
        public ReportCommandGroup(DiscordRestChannelAPI discordRestChannelApi)
        {
            _discordRestChannelApi = discordRestChannelApi;
        }
    }
}