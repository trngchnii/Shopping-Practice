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
                ParentId = category.ParentId
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

        public static CategoryDeleteDto ToCategoryDeleteDto(this Category category)
        {
            return new CategoryDeleteDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
    }
}