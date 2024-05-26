using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordSearchingGameAPI.DTOs;
using WordSearchingGameAPI.DTOs.Requests;
using WordSearchingGameAPI.DTOs.Responses;
using WordSearchingGameAPI.Service;

namespace WordSearchingGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProgressController : ControllerBase
    {
        private readonly UserProgressService _userProgressService;

        public UserProgressController(UserProgressService userProgressService)
        {
            _userProgressService = userProgressService;
        }

        //Create user progress
        [HttpPost]
        public async Task<ActionResult<UserProgressDTO?>> CreateUserProgressAsync(UserProgressDTO userProgressDTO)
        {
            var userProgress = await _userProgressService.CreateUserProgressAsync(userProgressDTO);
            if(userProgress == null)
            {
                return BadRequest();
            }
            return Ok(userProgress);
        }

        //Create user progress v2
        [HttpPost("v2")]
        public async Task<ActionResult<UserProgressDTO?>> CreateUserProgressV2Async(UserProgressRequest userProgressRequest)
        {
            var userProgress = await _userProgressService.CreateUserProgressV2Async(userProgressRequest);
            if(userProgress == null)
            {
                return BadRequest();
            }
            return Ok(userProgress);
        }

        //Get by userId
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserProgressResponse>>> GetUserProgressAsync(int userId)
        {
            var userProgress = await _userProgressService.GetUserProgressAsync(userId);
            if(userProgress == null)
            {
                return NotFound();
            }
            return Ok(userProgress);
        }
    }
}
