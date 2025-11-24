using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IRoleRepository _roleRepository;
        public AuthService(IUserRepository userRepository, IConfiguration configuration, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _roleRepository = roleRepository;
        }
        public async Task<UserResponseDto> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password.");
            if (user.IsActive == false)
                throw new Exception("Your account is banned. Contact fanpage to get more information.");
            var token = GenerateJwtToken(user);
            return user.ToUserResponseDto(token);
        }


        public async Task<UserResponseDto> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
                throw new Exception("Email is already in use.");

            var role = await _roleRepository.GetByNameAsync(dto.RoleName);

            if (role == null)
                throw new Exception("Invalid role specified.");

            var user = dto.ToUserFromRegisterDto(role.RoleId);
            await _userRepository.AddAsync(user);

            return user.ToUserResponseDto(null);

        }

        private string GenerateJwtToken(User user)
        {
            if (user.Role == null)
                throw new Exception("User role not loaded.");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("userId", user.UserId.ToString()),
                new Claim(ClaimTypes.Role, user.Role.RoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new Exception("JWT Key is null")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireMinutes = int.Parse(_configuration["Jwt:ExpireMinutes"] ?? "60");

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

