using System;
using System.Threading;
using System.Threading.Tasks;
using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.Gateway.Responders;
using Remora.Results;

namespace Trixy.Bot.Responders;

public class GuildAddResponder
    : IResponder<IGuildCreate>
{
    public Task<Result> RespondAsync(IGuildCreate gatewayEvent, CancellationToken ct = new())
    {
        throw new NotImplementedException();
    }
}