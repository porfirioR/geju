using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.User
{
    public class UpdateUserDTO : CreateUserDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
