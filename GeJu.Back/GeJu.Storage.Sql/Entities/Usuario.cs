using System;
using System.Collections.Generic;

namespace GeJu.Storage.Sql.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaNaciento { get; set; }
        public DateTime FechaCreado { get; set; }
        public bool Deuda { get; set; }
        public ICollection<UsuarioRol> UsuariosRoles { get; set; }

    }
}
