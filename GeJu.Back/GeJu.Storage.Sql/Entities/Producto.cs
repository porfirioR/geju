using System;
using System.Collections.Generic;

namespace GeJu.Sql.Entities
{
    public class Producto: BaseEntity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Existencia { get; set; }
        public int CostoPromedio { get; set; }
        public bool Vencimiento { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoBarra { get; set; }
        public int Cantidad { get; set; }
        public Color Color { get; set; }
        public int Precio { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int TamanhoId { get; set; }
        public Tamanho Tamanho { get; set; }
        public ICollection<ProductoColor> ProductosColores { get; set; }
        public ICollection<ProductoGrupo> ProductoGrupos { get; set; }
        public ICollection<ProductoSeccion> ProductoSecciones { get; set; }
    }
}
