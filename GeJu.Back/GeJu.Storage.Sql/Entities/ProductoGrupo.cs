namespace GeJu.Sql.Entities
{
    public class ProductoGrupo
    {
        public string ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
