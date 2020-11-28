using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.Brands
{
    public class CreateBrandDTO
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
