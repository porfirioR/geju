using System;

namespace GeJu.Sql.Entities
{
    public class ProductoTamaño
    {
        public Guid ProductoId { get; set; }
        public Producto Producto { get; set; }
        public Guid TamañoId { get; set; }
        public Tamaño Tamaño { get; set; }
        public int Cantidad { get; set; }
    }
}
