using System.Threading;
using System.Threading.Tasks;
using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.API.Gateway.Events;
using Remora.Discord.Gateway.Responders;
using Remora.Results;

using Trixy.DataAccess;
using Trixy.DataAccess.Models;
using Trixy.DataAccess.Users;

namespace Trixy.Bot.Responders
{
    public class FirstMessageRegistrationResponder
        : IResponder<IMessageCreate>
    {
        public Task<Result> RespondAsync(IMessageCreate gatewayEvent, CancellationToken ct = new CancellationToken())
        {
            using var context = new TrixyDbContext();
            var service = new UsersRepositoryService(context);
            var user = gatewayEvent.Author;

            if (!service.ExistsBySnowflake(user.ID))
            {
                var entity = new UserEntity(user.ID);
                service.AddEntityAsync(entity);
            }

            return Task.FromResult(Result.FromSuccess());
        }
    }
}