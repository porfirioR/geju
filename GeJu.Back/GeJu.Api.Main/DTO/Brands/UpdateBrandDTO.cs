using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Brands
{
    public class UpdateBrandDTO : CreateBrandDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
