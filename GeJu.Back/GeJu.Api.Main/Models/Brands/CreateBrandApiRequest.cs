using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Brands
{ 
    public class CreateBrandApiRequest
    {
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
