using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Sizes
{
    public class UpdateSizeDTO : CreateSizeDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
