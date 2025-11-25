using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = categories.Select(c => c.ToCategoryDto()).ToList();
            return Ok(categoryDtos);
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            var category = await _categoryRepository.AddAsync(dto.ToCategoryCreateDto());
            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = category.CategoryId }, category.ToCategoryDto());
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] CategoryCreateDto dto)
        {
            var result = await _categoryRepository.UpdateCategoryAsync(categoryId, dto);
            if (result == null)
                return NotFound();
            return Ok(result.ToCategoryDto());
        }
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeteleCategory([FromRoute] int categoryId)
        {
            try
            {
                var category = await _categoryRepository.DeleteAsync(categoryId);

                if (category == null)
                    return NotFound(new { message = "Category not found" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

    }
}