#nullable enable

using Remora.Discord.Core;
using System.Threading.Tasks;
using Trixy.DataAccess.Models;

namespace Trixy.DataAccess
{
    public interface IEntityRepository<T>
    {
        void AddEntityAsync(T entity);

        void RemoveEntityAsync(T entity);

        bool ExistsBySnowflake(Snowflake snowflake);

        Task<UserEntity> GetEntityBySnowflakeAsync(Snowflake snowflake);
    }
}