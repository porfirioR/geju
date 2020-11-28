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
        public bool Active { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastActive { get; set; }
        //public Country Country { get; set; }
    }
}
