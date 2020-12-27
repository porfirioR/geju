namespace GeJu.Sql.Entities
{
    public class ProductoTamaño
    {
        public string ProductoId { get; set; }
        public Producto Producto { get; set; }
        public string TamañoId { get; set; }
        public Tamaño Tamaño { get; set; }
        public int Cantidad { get; set; }
    }
}
