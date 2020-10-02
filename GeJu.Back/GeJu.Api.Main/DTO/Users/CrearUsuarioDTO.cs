using GeJu.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Users
{
    public class CrearUsuarioDTO
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Correo { get; set; }
        public bool Activo { get; set; }
        [Required]
        public Gender Genero { get; set; }
        [Required]
        public DateTime FechaNaciento { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime LastActive { get; set; }
        [Required]
        public Country Pais { get; set; }
    }
}
