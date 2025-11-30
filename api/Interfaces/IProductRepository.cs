using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> GetProductByIdAsync(int productId);
    }
}