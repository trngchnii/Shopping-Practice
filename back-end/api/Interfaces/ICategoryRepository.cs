using api.Dtos.Category;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> GetWithChildrenAsync(int categoryId);
        Task<List<Category>> GetParentCategoryAsync();
    }
}