namespace GeJu.Sql.Entities
{
    public class ProductoSeccion
    {
        public string ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public string SeccionId { get; set; }
        public virtual Seccion Seccion { get; set; }
    }
}
