using api.Dtos.Product;

namespace api.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto, IFormFile[] images);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto?> UpdateProductAsync(int productId, CreateProductDto updateProductDto, IFormFile[]? images);
        Task<bool> DeleteProductAsync(int productId);
    }
}