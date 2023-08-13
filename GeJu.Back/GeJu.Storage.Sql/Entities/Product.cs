namespace GeJu.Sql.Entities
{
    public class Product : BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Existencia { get; set; }
        //public int CostoPromedio { get; set; }
        //public bool Vencimiento { get; set; }
        public DateTime FechaVencimiento { get; set; }
        //public string CodigoBarra { get; set; }
        public int Cantidad { get; set; }
        //public virtual Color Color { get; set; }
        public int Precio { get; set; }
        public int MarcaId { get; set; }
        public virtual Marca Marca { get; set; }
        //public int TamanhoId { get; set; }
        //public virtual Tamanho Tamanho { get; set; }
        //public virtual ICollection<ProductoColor> ProductosColores { get; set; }
        //public virtual ICollection<ProductoGrupo> ProductoGrupos { get; set; }
        //public virtual ICollection<ProductoSeccion> ProductoSecciones { get; set; }
    }
}
