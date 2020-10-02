using GeJu.Common;
using System;

namespace Intermedio.Users
{
    public class CrearUsuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public Gender Genero { get; set; }
        public DateTime FechaNaciento { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime LastActive { get; set; }
        public Country Pais { get; set; }
    }
}
