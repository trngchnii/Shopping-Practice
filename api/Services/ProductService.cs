using api.Dtos.Product;
using api.Interfaces;
using api.Mappers;
using api.Models;

namespace api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;
        public ProductService(IProductRepository productRepository, IFileService fileService)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }
        public async Task<ProductDto> CreateProductAsync(CreateProductDto createProductDto, IFormFile[] images)
        {
            var product = createProductDto.ToCreateProductDto();
            await _productRepository.AddAsync(product);

            if (images != null && images.Length > 0)
            {
                foreach (var img in images)
                {
                    if (img == null) continue;
                    var path = await _fileService.SaveFileAsync(img);
                    product.Images ??= new List<ProductImage>();
                    product.Images.Add(new ProductImage { ImageUrl = path, ProductId = product.ProductId });
                }
                await _productRepository.SaveChangesAsync();
            }
            return product.ToProductDto();
        }

        public Task<bool> DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto?> UpdateProductAsync(int productId, UpdateProductDto updateProductDto, IFormFile[]? images)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null) return null;

            product.ToUpdateProductDto(updateProductDto);

            if (images != null && images.Length > 0)
            {
                foreach (var img in images)
                {
                    var path = await _fileService.SaveFileAsync(img, "products");
                    product.Images ??= new List<ProductImage>();
                    product.Images.Add(new ProductImage { ProductId = product.ProductId, ImageUrl = path, });
                }
            }

            await _productRepository.SaveChangesAsync();
            return product.ToProductDto();
        }
    }
}