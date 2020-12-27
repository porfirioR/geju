using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Tamaño: BaseEntity
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public IEnumerable<ProductoTamaño> ProductoTamaños { get; set; }
    }
}
