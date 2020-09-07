using System.Collections.Generic;

namespace GeJu.Storage.Sql.Entities
{
    public class Grupo: BaseEntity
    {
        public string Descripcion { get; set; }
        public ICollection<ProductoGrupo> ProductoGrupos { get; set; }

    }
}
