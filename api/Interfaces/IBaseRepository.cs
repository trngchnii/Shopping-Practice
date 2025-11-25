namespace api.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Query();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task<T> AddAsync(T entity, bool save = true);
        Task<T?> DeleteAsync(int id, bool save = true);
        Task<int> SaveChangesAsync();
    }

}