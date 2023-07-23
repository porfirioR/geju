namespace GeJu.Sql.Entities
{
    public class VentaDet : BaseEntity
    {
        public int ProductoId { get; set; }
        public int VentaCabId { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
