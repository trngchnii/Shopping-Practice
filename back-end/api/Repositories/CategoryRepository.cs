using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShoppingDBContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetParentCategoryAsync()
        {
            return await _dbSet.Where(c => c.ParentId == null).Include(c => c.SubCategories).ToListAsync();
        }

        public async Task<Category?> GetWithChildrenAsync(int categoryId)
        {
            return await _dbSet.Include(c => c.SubCategories).FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
    }
}