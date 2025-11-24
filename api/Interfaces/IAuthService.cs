using api.Dtos.User;

namespace api.Interfaces
{
    public interface IAuthService
    {
        Task<UserResponseDto> LoginAsync(UserLoginDto dto);
        Task<UserResponseDto> RegisterAsync(UserRegisterDto dto);
    }
}