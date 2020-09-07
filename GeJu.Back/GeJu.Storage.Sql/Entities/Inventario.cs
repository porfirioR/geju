namespace GeJu.Storage.Sql.Entities
{
    public class Inventario: BaseEntity
    {
        public int ProductoId { get; set; }
        public int CantidadSistema { get; set; }
        public string Descripcion { get; set; }
        public int CantidadFisica { get; set; }
    }
}
