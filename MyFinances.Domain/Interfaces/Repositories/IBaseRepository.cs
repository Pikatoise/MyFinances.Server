namespace MyFinances.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repository with base functions for database communication
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> CreateAsync(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);
    }
}
