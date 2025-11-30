using api.Dtos.Product;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(productId);

                if (product == null)
                    return NotFound();

                return Ok(product.ToProductDto());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductDto dto, [FromForm] List<IFormFile> imgs)
        {
            try
            {
                var product = await _productService.CreateProductAsync(dto, imgs.ToArray());
                return CreatedAtAction(nameof(GetProductById), new { productId = product.ProductId }, product);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}