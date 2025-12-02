using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var userDtos = users.Select(u => u.ToUserDto());
                return Ok(userDtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById([FromRoute] int userId)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user.ToUserDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, [FromBody] UpdateUserRequestDto updateUserDto)
        {
            try
            {
                var role = await _roleRepository.GetByNameAsync(updateUserDto.RoleName);

                if (role == null)
                {
                    return BadRequest($"Role '{updateUserDto.RoleName}' does not exist.");
                }

                var updatedUser = await _userRepository.UpdateUser(userId, updateUserDto.ToUserFromUpdateDTO(role.RoleId));

                if (updatedUser == null)
                {
                    return NotFound();
                }
                return Ok(updatedUser.ToUserDto());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int userId)
        {
            try
            {
                var userModel = await _userRepository.DeleteAsync(userId);

                if (userModel == null)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}