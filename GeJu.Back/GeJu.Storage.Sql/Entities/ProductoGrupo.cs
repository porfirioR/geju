namespace GeJu.Storage.Sql.Entities
{
    public class ProductoGrupo
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
