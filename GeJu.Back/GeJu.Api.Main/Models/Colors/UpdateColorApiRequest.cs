using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Colors
{
    public class UpdateColorApiRequest : CreateColorApiRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
