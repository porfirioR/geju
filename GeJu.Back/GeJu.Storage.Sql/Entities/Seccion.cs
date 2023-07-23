namespace GeJu.Sql.Entities
{
    public class Seccion : BaseEntity
    {
        public string Descripcion { get; set; }
        public virtual ICollection<ProductoSeccion> ProductoSecciones { get; set; }
    }
}
