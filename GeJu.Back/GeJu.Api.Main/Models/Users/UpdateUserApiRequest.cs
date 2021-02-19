using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Users
{
    public class UpdateUserApiRequest : CreateUserApiRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
