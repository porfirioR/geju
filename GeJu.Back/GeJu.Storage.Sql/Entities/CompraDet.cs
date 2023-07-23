namespace GeJu.Sql.Entities
{
    public class CompraDet : BaseEntity
    {
        public int ProductoId { get; set; }
        public int CompraCabId { get; set; }
        public int Costo { get; set; }
        public int Cantidad { get; set; }
    }
}
