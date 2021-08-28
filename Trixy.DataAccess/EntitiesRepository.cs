namespace Trixy.DataAccess
{
    public interface IEntitiesRepository<T>
    {
        void AddEntityAsync(T entity);
        void RemoveEntityAsync(T entity);
    }
}