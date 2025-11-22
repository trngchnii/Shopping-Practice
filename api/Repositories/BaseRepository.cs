using api.Data;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ShoppingDBContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(ShoppingDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IQueryable<T> Query() => _dbSet.AsQueryable();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(object id) => await _dbSet.FindAsync(id);

        public async Task<T> AddAsync(T entity, bool save = true)
        {
            await _dbSet.AddAsync(entity);
            if (save) await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity, bool save = true)
        {
            _dbSet.Update(entity);
            if (save) await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(object id, bool save = true)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;
            _dbSet.Remove(entity);
            if (save) await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }

}