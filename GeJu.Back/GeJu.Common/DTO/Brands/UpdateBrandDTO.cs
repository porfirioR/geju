using System;
using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.Brands
{
    public class UpdateBrandDTO : CreateBrandDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
