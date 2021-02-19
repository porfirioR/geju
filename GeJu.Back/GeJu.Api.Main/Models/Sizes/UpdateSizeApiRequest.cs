using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Sizes
{
    public class UpdateSizeApiRequest : CreateSizeApiRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
