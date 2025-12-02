using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryRepository categoryRepository, ICategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = categories.Select(c => c.ToCategoryDto()).ToList();
            return Ok(categoryDtos);
        }

        [HttpGet("parents")]
        public async Task<IActionResult> GetParentCategoryAsync()
        {
            var categories = await _categoryRepository.GetParentCategoryAsync();
            var categoryDtos = categories.Select(c => c.ToCategoryDto()).ToList();
            return Ok(categoryDtos);
        }
        [HttpGet("{categoryId}/children")]
        public async Task<IActionResult> GetCategoryWithChildren(int categoryId)
        {
            var category = await _categoryRepository.GetWithChildrenAsync(categoryId);

            if (category == null)
                return NotFound();

            return Ok(category.ToCategoryDto());
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category == null)
                return NotFound();
            return Ok(category.ToCategoryDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto dto)
        {
            try
            {
                var category = await _categoryService.CreateCategoryAsync(dto);
                return CreatedAtAction(nameof(GetCategoryById), new { categoryId = category.CategoryId }, category.ToCategoryDto());
            }
            catch (Exception ex)
            {

                return BadRequest(new { ex.Message });
            }
        }


        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] CategoryCreateDto dto)
        {
            try
            {
                var result = await _categoryService.UpdateCategoryAsync(categoryId, dto);
                if (result == false)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new { ex.Message });
            }
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