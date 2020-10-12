using GeJu.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Users
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
        [Required]
        public DateTime Birthdate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
        public Country Country { get; set; }
    }
}
