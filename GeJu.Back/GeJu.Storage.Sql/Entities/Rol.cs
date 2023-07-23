namespace GeJu.Sql.Entities
{
    public class Rol : BaseEntity
    {
        public string Descripcion { get; set; }
        public virtual ICollection<UsuarioRol> UsuariosRoles { get; set; }
    }
}
