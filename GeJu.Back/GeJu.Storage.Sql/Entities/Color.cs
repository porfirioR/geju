using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Color: BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<ProductoColor> ProductosColores { get; set; }
    }
}
