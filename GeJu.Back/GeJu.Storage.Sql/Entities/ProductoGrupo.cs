namespace GeJu.Sql.Entities
{
    public class ProductoGrupo
    {
        public string ProductoId { get; set; }
        public string GrupoId { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
