using System;

namespace GeJu.Sql.Entities
{
    public class RolPermiso
    {
        public Guid RolId { get; set; }
        public Guid PermisoId { get; set; }
        public bool Activo { get; set; }
        public virtual Permiso Permiso { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
