using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordSearchingGameAPI.Service;

namespace WordSearchingGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DifficultyController : ControllerBase
    {
        private readonly DifficultyService _difficultyService;

        public DifficultyController(DifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        //Get all difficulties
        [HttpGet]
        public async Task<IActionResult> GetAllDifficultiesAsync()
        {
            var result = await _difficultyService.GetAllDifficultiesAsync();
            return Ok(result);
        }
    }
}
