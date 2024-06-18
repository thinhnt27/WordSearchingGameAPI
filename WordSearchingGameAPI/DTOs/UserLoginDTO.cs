using System.ComponentModel.DataAnnotations;

namespace WordSearchingGameAPI.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
    }
}
