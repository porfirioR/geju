using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Color: BaseEntity
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public virtual IEnumerable<ProductoColor> ProductosColores { get; set; }
    }
}
