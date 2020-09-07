namespace GeJu.Storage.Sql.Entities
{
    public class ProductoSeccion
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int SeccionId { get; set; }
        public Seccion Seccion { get; set; }
    }
}
