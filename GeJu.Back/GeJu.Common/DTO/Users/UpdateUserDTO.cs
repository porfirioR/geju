using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.Users
{
    public class UpdateUserDTO : CreateUserDTO
    {
        [Required]
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
