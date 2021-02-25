using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Storage.Sql.Configurations
{
    //internal class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
    //{
    //    public void Configure(EntityTypeBuilder<Producto> builder)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    //}

    //public class ProductoGrupoConfiguracion : IEntityTypeConfiguration<ProductoGrupo>
    //{
    //    public void Configure(EntityTypeBuilder<ProductoGrupo> builder)
    //    {
    //        builder.HasKey(pg => new { pg.ProductoId, pg.GrupoId });
    //        builder.HasOne(pg => pg.Producto)
    //            .WithMany(p => p.ProductoGrupos)
    //            .HasForeignKey(pg => pg.ProductoId);
    //        builder.HasOne(pg => pg.Grupo)
    //            .WithMany(g => g.ProductoGrupos)
    //            .HasForeignKey(pg => pg.GrupoId);
    //    }
    //}

    //public class ProductoSeccionConfiguracion : IEntityTypeConfiguration<ProductoSeccion>
    //{
    //    public void Configure(EntityTypeBuilder<ProductoSeccion> builder)
    //    {
    //        builder.HasOne(ps => ps.Producto)
    //            .WithMany(p => p.ProductoSecciones)
    //            .HasForeignKey(ps => ps.ProductoId);
    //        builder.HasOne(ps => ps.Seccion)
    //            .WithMany(s => s.ProductoSecciones)
    //            .HasForeignKey(ps => ps.SeccionId);
    //        builder.HasKey(ps => new { ps.ProductoId, ps.SeccionId });
    //    }
    //}

    //public class ProductoColorConfiguracion : IEntityTypeConfiguration<ProductoColor>
    //{
    //    public void Configure(EntityTypeBuilder<ProductoColor> builder)
    //    {
    //        builder.HasOne(pc => pc.Producto)
    //            .WithMany(p => p.ProductosColores)
    //            .HasForeignKey(pc => pc.ProductoId);
    //        builder.HasOne(ps => ps.Color)
    //            .WithMany(c => c.ProductosColores)
    //            .HasForeignKey(pc => pc.ColorId);
    //        builder.HasKey(pc => new { pc.ProductoId, pc.ColorId });
    //    }
    //}

    public class ProductoTamañoConfiguracion : IEntityTypeConfiguration<ProductoTamaño>
    {
        public void Configure(EntityTypeBuilder<ProductoTamaño> builder)
        {
            builder.HasOne(pc => pc.Producto)
                .WithMany(p => p.ProductoTamaños)
                .HasForeignKey(pc => pc.ProductoId);

            builder.HasOne(ps => ps.Tamaño)
                .WithMany(c => c.ProductoTamaños)
                .HasForeignKey(pc => pc.TamañoId);

            builder.HasKey(pc => new { pc.ProductoId, pc.TamañoId });

            builder.Property(pt => pt.Cantidad).HasDefaultValue(0);
        }
    }
}
