using System.ComponentModel.DataAnnotations;

namespace GeJu.Api.Main.DTO.Users
{
    public class ActualizarUsuarioDTO : CrearUsuarioDTO
    {
        [Required]
        public string Id { get; set; }
    }
}
