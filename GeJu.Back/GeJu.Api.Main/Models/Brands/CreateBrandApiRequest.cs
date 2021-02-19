using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Brands
{ 
    public class CreateBrandApiRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
