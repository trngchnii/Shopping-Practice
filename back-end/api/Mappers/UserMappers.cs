using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserId = userModel.UserId,
                Email = userModel.Email,
                FullName = userModel.FullName,
                RoleId = userModel.RoleId,
                Role = userModel.Role == null ? null : new Role
                {
                    RoleId = userModel.Role.RoleId,
                    RoleName = userModel.Role.RoleName
                },
                AvatarUrl = userModel.AvatarUrl,
                DateOfBirth = userModel.DateOfBirth,
                CreatedAt = userModel.CreatedAt,
                IsActive = userModel.IsActive
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto createUserRequestDto, int roleId)
        {
            return new User
            {
                Email = createUserRequestDto.Email,
                FullName = createUserRequestDto.FullName,
                RoleId = roleId,
                AvatarUrl = createUserRequestDto.AvatarUrl,
                DateOfBirth = createUserRequestDto.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
        }

        public static User ToUserFromUpdateDTO(this UpdateUserRequestDto updateUserRequestDto, int roleId)
        {
            return new User
            {
                Email = updateUserRequestDto.Email,
                FullName = updateUserRequestDto.FullName,
                RoleId = roleId,
                AvatarUrl = updateUserRequestDto.AvatarUrl,
                DateOfBirth = updateUserRequestDto.DateOfBirth,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
        }

        public static User ToUserFromRegisterDto(this UserRegisterDto dto, int roleId)
        {
            return new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                RoleId = roleId,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };
        }

        public static UserResponseDto ToUserResponseDto(this User user, string token)
        {
            return new UserResponseDto
            {
                UserId = user.UserId,
                Email = user.Email,
                FullName = user.FullName,
                RoleName = user.Role.RoleName,
                Token = token
            };
        }

    }
}