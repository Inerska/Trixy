using System;
using System.Threading;
using System.Threading.Tasks;
using Remora.Discord.API.Gateway.Events;
using Remora.Discord.Gateway.Responders;
using Remora.Results;

namespace Trixy.Bot.Responders
{
    public class FirstMessageRegistrationResponder
        : IResponder<MessageCreate>
    {
        public Task<Result> RespondAsync(MessageCreate gatewayEvent, CancellationToken ct = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}