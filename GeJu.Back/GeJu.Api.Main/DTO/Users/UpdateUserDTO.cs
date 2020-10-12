using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Users
{
    public class UpdateUserDTO : CreateUserDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
