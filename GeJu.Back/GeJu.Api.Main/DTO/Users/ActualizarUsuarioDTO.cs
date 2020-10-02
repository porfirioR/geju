using GeJu.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Users
{
    public class ActualizarUsuarioDTO
    {
        [Required]
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool Active { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        [Required]
        public Country Country { get; set; }
    }
}
