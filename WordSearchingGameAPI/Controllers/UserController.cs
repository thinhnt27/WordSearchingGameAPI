using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.Models;
using WordSearchingGameAPI.Service;

namespace WordSearchingGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        //Create User
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDTO userDTO)
        {
            var result = await _userService.CreateUserAsync(userDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        //Get All Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }
        //Get User By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
