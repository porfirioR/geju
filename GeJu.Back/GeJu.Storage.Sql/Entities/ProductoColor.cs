namespace GeJu.Sql.Entities
{
    public class ProductoColor
    {
        public int ProductoId { get; set; }
        public int ColorId { get; set; }

        public virtual Producto Producto { get; set; }
        public virtual Color Color { get; set; }
    }
}
