using api.Dtos.Category;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateCategoryAsync(CategoryCreateDto category);

        Task<bool> UpdateCategoryAsync(int categoryId, CategoryCreateDto dto);
    }
}