using api.Data;
using api.Dtos.Category;
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

        public async Task<Category?> UpdateCategoryAsync(int categoryId, CategoryCreateDto category)
        {
            var existCategory = await GetByIdAsync(categoryId);

            if (existCategory == null)
                return null;

            existCategory.CategoryName = category.CategoryName;
            existCategory.ParentId = category.ParentId;
            await SaveChangesAsync();
            return existCategory;
        }
    }
}