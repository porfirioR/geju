namespace GeJu.Sql.Entities
{
    public class Grupo : BaseEntity
    {
        public string Descripcion { get; set; }
        public virtual ICollection<ProductoGrupo> ProductoGrupos { get; set; }

    }
}
