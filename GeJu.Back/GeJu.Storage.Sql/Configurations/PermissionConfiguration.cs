using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sql.Configurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
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
                .Property(m => m.Nombre)
                .HasMaxLength(25)
                .IsUnicode();
        }
    }

    internal class RolePermissionConfiguration : IEntityTypeConfiguration<RolPermiso>
    {
        public void Configure(EntityTypeBuilder<RolPermiso> builder)
        {
            builder.HasKey(x => new { x.PermisoId, x.RolId });

            builder.HasOne(rp => rp.Rol)
                .WithMany(r => r.RolPermisos)
                .HasForeignKey(rp => rp.RolId);
            
            builder.HasOne(rp => rp.Permiso)
                .WithMany(r => r.RolPermisos)
                .HasForeignKey(rp => rp.PermisoId);
        }
    }

}
