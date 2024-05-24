using System.ComponentModel.DataAnnotations;

namespace WordSearchingGameAPI.DTOs
{
    public class UserProgressDTO
    {

        [Required(ErrorMessage = "Please enter the user ID")]
        public int UserId { get; set; }

        //public int? TopicId { get; set; }

        //public int? DifficultyId { get; set; }

        [Required(ErrorMessage = "Please enter the level ID")]
        public int LevelId { get; set; }

        [Required(ErrorMessage = "Please enter the completion status")]
        public bool? Completed { get; set; }

        [Required(ErrorMessage = "Please enter the completion time")]
        public DateTime CompletionTime { get; set; }
    }
}
