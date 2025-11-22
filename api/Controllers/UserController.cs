using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserController(IBaseRepository<User> userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = users.Select(u => u.ToUserDto());
            return Ok(userDtos);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            var role = await _roleRepository.GetByNameAsync(userDto.RoleName);
            if (role == null)
            {
                return BadRequest($"Role '{userDto.RoleName}' does not exist.");
            }
            var userModel = userDto.ToUserFromCreateDTO(role.RoleId);

            await _userRepository.AddAsync(userModel);

            return CreatedAtAction(nameof(GetUserById), new { userId = userModel.UserId }, userModel.ToUserDto());
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UpdateUserRequestDto updateUserDto)
        {
            var userModel = await _userRepository.GetByIdAsync(userId);

            if (userModel == null)
            {
                return NotFound();
            }

            var role = await _roleRepository.GetByNameAsync(updateUserDto.RoleName);

            if (role == null)
            {
                return BadRequest($"Role '{updateUserDto.RoleName}' does not exist.");
            }

            userModel.Email = updateUserDto.Email;
            userModel.FullName = updateUserDto.FullName;
            userModel.RoleId = role.RoleId;
            userModel.AvatarUrl = updateUserDto.AvatarUrl;
            userModel.DateOfBirth = updateUserDto.DateOfBirth;

            await _userRepository.SaveChangesAsync();

            return Ok(userModel.ToUserDto());
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            var userModel = await _userRepository.DeleteAsync(userId);

            if (!userModel)
                return NotFound();

            return NoContent();
        }

    }
}