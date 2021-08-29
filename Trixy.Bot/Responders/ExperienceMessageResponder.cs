using System.Threading;
using System.Threading.Tasks;
using Remora.Discord.API.Abstractions.Gateway.Events;
using Remora.Discord.Gateway.Responders;
using Remora.Results;
using Trixy.DataAccess;
using Trixy.DataAccess.Users;

namespace Trixy.Bot.Responders
{
    public class ExperienceMessageResponder
        : IResponder<IMessageCreate>
    {
        public async Task<Result> RespondAsync(IMessageCreate gatewayEvent, CancellationToken ct = new CancellationToken())
        {
            await using var context = new TrixyDbContext();
            var service = new UsersRepositoryService(context);
            var userDatabase = await service.GetEntityBySnowflakeAsync(gatewayEvent.Author.ID);

            
            
            return await Task.FromResult(Result.FromSuccess());
        }
    }
}