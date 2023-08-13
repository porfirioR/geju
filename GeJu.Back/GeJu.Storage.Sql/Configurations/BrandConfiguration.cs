using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Sql.Configurations
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder
                .Property(d => d.FechaCreado)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(d => d.FechaModificado)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(m => m.Descripcion)
                .HasMaxLength(100);

            builder
                .Property(m => m.Nombre)
                .HasMaxLength(25)
                .IsUnicode();
        }
    }
}
