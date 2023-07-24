namespace GeJu.Sql.Entities
{
    public class VentaCab : BaseEntity
    {
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public bool CondicionVenta { get; set; }
    }
}
