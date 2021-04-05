using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.Models.Colors
{ 
    public class CreateColorApiRequest
    {
        [Required]
        [StringLength(7)]
        public string Code { get; set; }
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
