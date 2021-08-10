/*using Remora.Commands.Parsers;
using Remora.Discord.API.Abstractions.Objects;
using Remora.Discord.API.Abstractions.Rest;
using Remora.Discord.Commands.Contexts;
using Remora.Discord.Rest.API;
using Remora.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Trixy.Bot.Parsers
{
    public class GuildUserParser
        : AbstractTypeParser<IReadOnlyList<IGuildMember>>
    {
        public GuildUserParser(
            ICommandContext context,
            IDiscordRestChannelAPI channelApi,
            DiscordRestGuildAPI discordRestGuildApi)
        {
            _context = context;
            _channelApi = channelApi;
            _discordRestGuildApi = discordRestGuildApi;
        }

        public override async ValueTask<Result<IReadOnlyList<IGuildMember>>> TryParse(string value, CancellationToken ct)
        {
            return await _discordRestGuildApi.SearchGuildMembersAsync(_context.GuildID.Value, value, 10, ct);
        }

        private readonly ICommandContext _context;
        private readonly IDiscordRestChannelAPI _channelApi;
        private readonly DiscordRestGuildAPI _discordRestGuildApi;
    }
}
*/

