using System.Collections.Generic;

namespace GeJu.Storage.Sql.Entities
{
    public class Rol: BaseEntity
    {
        public string Descripcion { get; set; }
        virtual public ICollection<UsuarioRol> UsuariosRoles { get; set; }
    }
}
