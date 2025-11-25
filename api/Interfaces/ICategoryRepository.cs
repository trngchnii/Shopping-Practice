using api.Dtos.Category;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> UpdateCategoryAsync(int categoryId, CategoryCreateDto category);
    }
}