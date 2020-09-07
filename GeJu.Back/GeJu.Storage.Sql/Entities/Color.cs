using System.Collections.Generic;

namespace GeJu.Storage.Sql.Entities
{
    public class Color: BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<ProductoColor> ProductosColores { get; set; }
    }
}
