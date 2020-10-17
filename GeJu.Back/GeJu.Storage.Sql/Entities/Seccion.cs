using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Seccion: BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<ProductoSeccion> ProductoSecciones { get; set; }
    }
}
