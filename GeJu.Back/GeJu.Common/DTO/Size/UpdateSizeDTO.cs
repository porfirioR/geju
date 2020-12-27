using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.Size
{
    public class UpdateSizeDTO : CreateSizeDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
