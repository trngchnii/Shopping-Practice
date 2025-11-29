using api.Dtos.Category;
using api.Models;

namespace api.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryResponeDto ToCategoryDto(this Category category)
        {
            return new CategoryResponeDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                ParentId = category.ParentId,
            };
        }

        public static Category ToCategoryCreateDto(this CategoryCreateDto categoryCreateDto)
        {
            return new Category
            {
                CategoryName = categoryCreateDto.CategoryName,
                ParentId = categoryCreateDto.ParentId
            };
        }

        public static void ToCategoryUpdateDto(this Category category, CategoryCreateDto categoryUpdateDto)
        {
            category.CategoryName = categoryUpdateDto.CategoryName;
            category.ParentId = categoryUpdateDto.ParentId;
        }

        public static CategoryDeleteDto ToCategoryDeleteDto(this Category category)
        {
            return new CategoryDeleteDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public static CategoryTreeDto ToCategoryTreeDto(this Category category)
        {
            return new CategoryTreeDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                SubCategories = category.SubCategories?.Select(c => c.ToCategoryTreeDto()).ToList() ?? new List<CategoryTreeDto>()
            };
        }
    }
}