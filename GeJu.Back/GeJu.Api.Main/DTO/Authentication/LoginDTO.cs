using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.Authentication
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
