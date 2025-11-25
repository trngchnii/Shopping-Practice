using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public readonly IRoleRepository _roleRepository;
        public UserRepository(ShoppingDBContext context, IRoleRepository roleRepository) : base(context)
        {
            _roleRepository = roleRepository;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _dbSet.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> UpdateUser(int userId, UpdateUserRequestDto updateUserDto)
        {
            var userModel = await GetByIdAsync(userId);

            if (userModel == null)
                return null;

            var role = await _roleRepository.GetByNameAsync(updateUserDto.RoleName);

            if (role == null)
                return null;

            userModel.Email = updateUserDto.Email;
            userModel.FullName = updateUserDto.FullName;
            userModel.RoleId = role.RoleId;
            userModel.AvatarUrl = updateUserDto.AvatarUrl;
            userModel.DateOfBirth = updateUserDto.DateOfBirth;

            await SaveChangesAsync();

            return userModel;
        }

        public async Task UpdateUserFieldsAsync(User user)
        {
            _dbSet.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}