using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Rol : BaseEntity
    {
        public string Descripcion { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<UsuarioRol> UsuariosRoles { get; set; }
        public virtual IEnumerable<RolPermiso> RolPermisos { get; set; }
    }
}
