using MyFinances.Domain.Interfaces.Repositories;

namespace MyFinances.DAL.Repositories
{
    public class BaseRepository<TEntity>(ApplicationDbContext context): IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _dbContext = context;

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            await _dbContext.AddAsync(entity);

            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            _dbContext.Remove(entity);

            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            _dbContext.Update(entity);

            return entity;
        }
    }
}
