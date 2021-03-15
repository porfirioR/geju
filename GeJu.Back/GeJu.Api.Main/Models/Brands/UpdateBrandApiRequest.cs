using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Brands
{
    public class UpdateBrandApiRequest : CreateBrandApiRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
