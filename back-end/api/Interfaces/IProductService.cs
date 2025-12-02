using api.Dtos.Product;

namespace api.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto, IFormFile[] images);
        Task<ProductDto?> UpdateProductAsync(int productId, UpdateProductDto updateProductDto, IFormFile[]? images);
        Task<bool> DeleteProductAsync(int productId);
    }
}