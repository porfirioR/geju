using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Sizes
{
    public class CreateSizeApiRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
