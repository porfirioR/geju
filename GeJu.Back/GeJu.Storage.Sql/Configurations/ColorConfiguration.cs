using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Sql.Configurations
{
    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(u => u.Id);

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
                .Property(m => m.Codigo)
                .HasMaxLength(7)
                .IsUnicode();
        }
    }
}
