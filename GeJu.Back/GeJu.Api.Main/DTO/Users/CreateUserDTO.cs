using GeJu.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GeJu.Common.DTO.Users
{
    public class CreateUserDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public CountryType Country { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
    }
}
