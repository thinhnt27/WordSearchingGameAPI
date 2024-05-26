using System.ComponentModel.DataAnnotations;

namespace WordSearchingGameAPI.DTOs.Requests
{
    public class UserProgressRequest
    {
        [Required(ErrorMessage = "Please enter the user ID")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter the DifficultyLevel")]
        public string? DifficultyLevel { get; set; }

        [Required(ErrorMessage = "Please enter the topic name")]
        public string? TopicName { get; set; }

        [Required(ErrorMessage = "Please enter the level number")]
        public int LevelNumber { get; set; }

        [Required(ErrorMessage = "Please enter the completion status")]
        public bool? Completed { get; set; }

        [Required(ErrorMessage = "Please enter the completion time")]
        public DateTime CompletionTime { get; set; }
    }
}
