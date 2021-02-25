using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Sql.Configurations
{
    internal class SizeConfiguration : IEntityTypeConfiguration<Tamaño>
    {
        public void Configure(EntityTypeBuilder<Tamaño> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Codigo).IsUnicode();

            builder
                .Property(u => u.FechaCreado)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(d => d.FechaModificado)
                .HasDefaultValueSql("GetUtcDate()");
        }
    }
}
