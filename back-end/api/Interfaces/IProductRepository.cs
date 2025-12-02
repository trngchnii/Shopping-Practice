using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product?> GetProductByIdAsync(int productId);
        Task UpdateAsync(Product product);
    }
}