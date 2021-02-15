using GeJu.Common;
using GeJu.Common.Enums;
using System;
using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Documento { get; set; }
        public DateTime FechaNaciento { get; set; }
        public DateTime UltimoInicio { get; set; }
        public bool Deuda { get; set; }
        public CountryType Pais { get; set; }
        public byte[] ContraseñaHash { get; set; }
        public byte[] ContraseñaSalt { get; set; }
        virtual public ICollection<UsuarioRol> UsuariosRoles { get; set; }
    }
}
