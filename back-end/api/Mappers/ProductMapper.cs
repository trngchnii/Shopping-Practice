using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
    public static class ProductMapper
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                ProductId = product.ProductId,
                Sku = product.Sku,
                ProductName = product.ProductName,
                Slug = product.Slug,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Discount = product.Discount,
                CategoryName = product.Category?.CategoryName,
                BrandName = product.Brand?.BrandName,
                IsActive = product.IsActive,
                ImageUrls = product.Images?.Select(img => img.ImageUrl).ToList() ?? new List<string>()
            };
        }
        public static Product ToCreateProductDto(this CreateProductDto dto)
        {
            return new Product
            {
                Sku = dto.Sku,
                ProductName = dto.ProductName,
                Slug = dto.Slug,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Discount = dto.Discount,
                CategoryId = dto.CategoryId,
                BrandId = dto.BrandId,
                IsActive = dto.IsActive
            };
        }

        public static void ToUpdateProductDto(this Product product, UpdateProductDto dto)
        {
            product.Sku = dto.Sku;
            product.ProductName = dto.ProductName;
            product.Slug = dto.Slug;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.StockQuantity = dto.StockQuantity;
            product.Discount = dto.Discount;
            product.CategoryId = dto.CategoryId;
            product.BrandId = dto.BrandId;
            product.IsActive = dto.IsActive;
            product.UpdatedAt = DateTime.UtcNow;
        }
    }
}