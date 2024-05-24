using System.ComponentModel.DataAnnotations;

namespace WordSearchingGameAPI.DTOs
{
    public class UserDTO
    {
        public int? UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Length must be between 10 to 50")]
        public string Username { get; set; }

        public string? PasswordHash { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "Length must be between 10 to 50")]
        public string Email { get; set; }

        public DateTime? DateJoined { get; set; } = DateTime.Now;
    }
}
