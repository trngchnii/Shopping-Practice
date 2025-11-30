using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(ShoppingDBContext context) : base(context)
        {
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.ProductId == productId);
        }
    }
}