using System;

namespace GeJu.Sql.Entities
{
    public class Imagen: BaseEntity
    {
        public Guid ProductoId { get; set; }
        public string Url { get; set; }
        public bool Principal { get; set; }
        public Producto Producto { get; set; }
    }
}
