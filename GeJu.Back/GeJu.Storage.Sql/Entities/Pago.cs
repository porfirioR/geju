namespace GeJu.Sql.Entities
{
    public class Pago : BaseEntity
    {
        public int VentaCabId { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
