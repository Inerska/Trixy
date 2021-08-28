namespace Trixy.DataAccess
{
    public interface IEntitiesRepository<in T>
    {
        void AddEntityAsync(T entity);
        void RemoveEntityAsync(T entity);
    }
}