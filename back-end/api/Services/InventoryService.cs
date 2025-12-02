using api.Interfaces;

namespace api.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> CheckStockAsync(int productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null) return false;

            return product.StockQuantity >= quantity;
        }

        public async Task DecreaseStockAsync(int productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId) ?? throw new Exception("Product not found");

            if (product.StockQuantity < quantity)
            {
                throw new Exception("Not enough stock");
            }

            product.StockQuantity -= quantity;

            await _productRepository.UpdateAsync(product);


        }

        public async Task IncreaseStockAsync(int productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId) ?? throw new Exception("Product not found");

            product.StockQuantity += quantity;

            await _productRepository.UpdateAsync(product);

        }
    }
}