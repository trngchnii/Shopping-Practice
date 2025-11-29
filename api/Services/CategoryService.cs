using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> CreateCategoryAsync(CategoryCreateDto dto)
        {
            if (dto.ParentId.HasValue)
            {
                var parent = await _categoryRepository.GetByIdAsync(dto.ParentId.Value);
                if (parent == null)
                {
                    throw new ArgumentException("Parent category does not exist.");
                }
            }

            var category = dto.ToCategoryCreateDto();
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> UpdateCategoryAsync(int categoryId, CategoryCreateDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null) return false;

            // Check for parent loop
            if (dto.ParentId.HasValue)
            {
                if (dto.ParentId.Value == categoryId)
                    throw new ArgumentException("ParentId cannot be the same as the CategoryId");

                var parent = await _categoryRepository.GetByIdAsync(dto.ParentId.Value);
                if (parent == null)
                    throw new ArgumentException("Parent category does not exist");

                // Check for deep circular reference
                if (await IsCircularReference(categoryId, dto.ParentId.Value))
                    throw new ArgumentException("The ParentId structure creates an invalid loop");
            }

            category.ToCategoryUpdateDto(dto); // map update DTO to entity
            await _categoryRepository.SaveChangesAsync();
            return true;
        }

        private async Task<bool> IsCircularReference(int categoryId, int parentId)
        {
            if (parentId == categoryId) return true; // immediate loop

            var parent = await _categoryRepository.GetByIdAsync(parentId);
            if (parent == null || !parent.ParentId.HasValue) return false;

            return await IsCircularReference(categoryId, parent.ParentId.Value);
        }
    }
}