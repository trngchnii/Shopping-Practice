using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ShoppingDBContext context) : base(context)
        {
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}