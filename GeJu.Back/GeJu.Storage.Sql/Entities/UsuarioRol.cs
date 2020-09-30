namespace GeJu.Storage.Sql.Entities
{
    public class UsuarioRol
    {
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public string RolId { get; set; }
        public Rol Rol { get; set; }
    }
}
