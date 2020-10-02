namespace GeJu.Storage.Sql.Entities
{
    public class ProductoSeccion
    {
        public string ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string SeccionId { get; set; }
        public Seccion Seccion { get; set; }
    }
}
