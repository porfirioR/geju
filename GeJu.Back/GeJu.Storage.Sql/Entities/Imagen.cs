namespace GeJu.Sql.Entities
{
    public class Imagen : BaseEntity
    {
        public int ProductoId { get; set; }
        public string Url { get; set; }
        public bool Principal { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
