using System;

namespace GeJu.Sql.Entities
{
    public class ProductoTamaño
    {
        public Guid ProductoId { get; set; }
        public Guid TamañoId { get; set; }
        public int Cantidad { get; set; }
        public virtual Producto Producto { get; set; }
        public virtual Tamaño Tamaño { get; set; }
    }
}
