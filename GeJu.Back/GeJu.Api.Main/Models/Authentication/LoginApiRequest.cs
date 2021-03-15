using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Authentication
{
    public class LoginApiRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
