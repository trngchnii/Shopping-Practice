using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<User?> UpdateUser(int userId, User updateUserDto);
        Task UpdateUserFieldsAsync(User user);
    }
}