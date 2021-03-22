using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sql.Configurations
{
    internal class ImageConfiguration : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> builder)
        {
            builder.HasKey(i => i.Id);

            builder
                .Property(i => i.FechaCreado)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(i => i.FechaModificado)
                .HasDefaultValueSql("GetUtcDate()");
        }
    }
}
