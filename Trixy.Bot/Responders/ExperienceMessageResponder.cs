using System;
using System.Security.Cryptography.X509Certificates;
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

            var canEarnExperiences = new Random().Next(0, 3) == 2;
            var experienceAmount = new Random().Next(8, 16);
            
            if (canEarnExperiences)
                service.EarnExperience(userDatabase, experienceAmount);
            
            return await Task.FromResult(Result.FromSuccess());
        }
    }
}