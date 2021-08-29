using System;
using Remora.Discord.Core;

namespace Trixy.DataAccess
{
    public interface IEntityRepository<in T>
    {
        void AddEntityAsync(T entity);
        void RemoveEntityAsync(T entity);
        bool ExistsBySnowflake(Snowflake snowflake);
    }
}