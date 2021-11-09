using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.Gateway.Responders;
using Remora.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Trixy.Bot.Responders
{
    public class GuildAddResponder
        : IResponder<IGuildCreate>
    {
        public Task<Result> RespondAsync(IGuildCreate gatewayEvent, CancellationToken ct = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}