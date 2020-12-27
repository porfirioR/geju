using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Sql.Configurations
{
    internal class TamañoConfiguracion : IEntityTypeConfiguration<Tamaño>
    {
        public void Configure(EntityTypeBuilder<Tamaño> builder)
        {
            builder.HasKey(u => u.Id);
            builder
                .Property(u => u.FechaCreado)
                .HasDefaultValueSql("GetUtcDate()");
            builder
                .Property(d => d.FechaModificado)
                .HasDefaultValueSql("GetUtcDate()");
        }

    }
}
