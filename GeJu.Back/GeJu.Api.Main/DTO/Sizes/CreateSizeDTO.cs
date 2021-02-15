using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Sizes
{
    public class CreateSizeDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
