﻿namespace GeJu.Sql.Entities
{
    public class ProductoColor
    {
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
}
