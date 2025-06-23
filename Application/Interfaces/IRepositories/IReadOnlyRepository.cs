namespace Application.Interfaces.IRepositories
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(params object[] id);
        IQueryable<TEntity> Query();
    }
}
