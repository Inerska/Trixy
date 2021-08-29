using System;

namespace Trixy.DataAccess
{
    public interface IEntityRepository<in T>
    {
        void AddEntityAsync(T entity);
        void RemoveEntityAsync(T entity);
    }
}