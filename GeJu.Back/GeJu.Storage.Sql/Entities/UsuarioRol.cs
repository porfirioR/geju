namespace GeJu.Sql.Entities
{
    public class UsuarioRol
    {
        public Guid UsuarioId { get; set; }
        public Guid RolId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
