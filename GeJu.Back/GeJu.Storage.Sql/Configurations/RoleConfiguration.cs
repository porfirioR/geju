using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sql.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
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
        }
    }
}
