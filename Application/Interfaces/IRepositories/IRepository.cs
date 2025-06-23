namespace Application.Interfaces.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
        {
            Task<IEnumerable<TEntity>> GetAllAsync();
            Task<TEntity?> GetByIdAsync(params object[] id);
            Task<TEntity> AddAsync(TEntity entity);
            Task UpdateAsync(TEntity entity);
            Task DeleteAsync(TEntity entity);
            IQueryable<TEntity> Query();
        }
}
