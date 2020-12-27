using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.Size
{
    public class CreateSizeDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
