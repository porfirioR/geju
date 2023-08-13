namespace GeJu.Sql.Entities
{
    public class ProductoSeccion
    {
        public string ProductoId { get; set; }
        public virtual Product Producto { get; set; }
        public string SeccionId { get; set; }
        public virtual Seccion Seccion { get; set; }
    }
}
