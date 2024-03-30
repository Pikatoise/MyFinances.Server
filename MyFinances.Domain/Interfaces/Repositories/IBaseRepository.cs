namespace MyFinances.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> CreateAsync(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Delete(TEntity entity);
    }
}
