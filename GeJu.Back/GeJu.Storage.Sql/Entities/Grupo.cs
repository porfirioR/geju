using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Grupo: BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<ProductoGrupo> ProductoGrupos { get; set; }

    }
}
