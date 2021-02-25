using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Tamaño: BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public virtual IEnumerable<ProductoTamaño> ProductoTamaños { get; set; }
    }
}
