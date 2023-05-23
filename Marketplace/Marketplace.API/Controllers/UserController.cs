using Marketplace.Interfaces.Services;
using Marketplace.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<UserResponseDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("user")]
        public async Task<ActionResult<List<UserResponseDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost("user")]
        public async Task<ActionResult<int>> CreateUser(UserCreateDto user)
        {
            var userId = await _userService.SaveUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }

        [HttpPut("user")]
        public async Task<ActionResult> UpdateUser(UserUpdateDto user)
        {
            await _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("user/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpPost("user/{id}/changepassword")]
        public async Task<ActionResult> ChangePassword(int id, string password)
        {
            await _userService.UserChangePassword(id, password);
            return Ok();
        }
    }
}
