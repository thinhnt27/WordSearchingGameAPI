using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordSearchingGameAPI.Service;
using WordSearchingGameAPI.UnitOfWorks;

namespace WordSearchingGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly WordService _wordService;

        public WordController(WordService wordService)
        {
            _wordService = wordService;
        }


        //Get words by topicId and difficultyId
        [HttpGet("{topicId}/{difficultyId}")]
        public async Task<IActionResult> GetWordsByTopicIdAndDifficultyIdAsync(int topicId, int difficultyId)
        {
            var result = await _wordService.GetWordsByTopicIdAndDifficultyIdAsync(topicId, difficultyId);
            return Ok(result);
        }
    }
}
