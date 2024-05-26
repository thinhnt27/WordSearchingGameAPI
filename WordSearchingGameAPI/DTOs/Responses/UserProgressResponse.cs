using WordSearchingGameAPI.Models;

namespace WordSearchingGameAPI.DTOs.Responses
{
    public class UserProgressResponse
    {
        public int? UserId { get; set; }
        public int? TopicId { get; set; }
        public string TopicName { get; set; }
        public int? DifficultyId { get; set; }
        public string DifficultyLevel { get; set; }
        public int? LevelId { get; set; }
        public int LevelNumber { get; set; }
        public bool? Completed { get; set; }
        public DateTime? CompletionTime { get; set; }
    }
}
