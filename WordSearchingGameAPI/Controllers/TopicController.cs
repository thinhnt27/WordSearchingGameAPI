using Microsoft.AspNetCore.Mvc;
using WordSearchingGameAPI.Service;

namespace WordSearchingGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly TopicService _topicService;

        public TopicController(TopicService topicService)
        {
            _topicService = topicService;
        }

        //Get all topics
        [HttpGet]
        public async Task<IActionResult> GetAllTopicsAsync()
        {
            var result = await _topicService.GetAllTopicsAsync();
            return Ok(result);
        }
    }
}
