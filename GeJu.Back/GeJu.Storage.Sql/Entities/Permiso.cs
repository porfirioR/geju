using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Permiso : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual IEnumerable<RolPermiso> RolPermisos { get; set; }
    }
}
