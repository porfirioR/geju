using System;

namespace GeJu.Sql.Entities
{
    public class ProductoColor
    {
        public Guid ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public Guid ColorId { get; set; }
        public virtual Color Color { get; set; }
    }
}
