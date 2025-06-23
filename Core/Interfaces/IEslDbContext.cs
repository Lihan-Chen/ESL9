namespace Core.Interfaces
{
    public interface IEslDbContext : IDisposable
    {
        ISet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
