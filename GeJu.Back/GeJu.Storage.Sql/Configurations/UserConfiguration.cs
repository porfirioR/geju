using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Sql.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            
            builder
                .Property(u => u.FechaCreado)
                .HasDefaultValueSql("GetUtcDate()");
            
            builder
                .Property(d => d.FechaModificado)
                .HasDefaultValueSql("GetUtcDate()");
            
            builder
                .HasIndex(u => u.Correo)
                .IsUnique();

            builder
                .HasIndex(u => u.Documento)
                .IsUnique();
        }

    }
    internal class UsuarioRolConfiguracion : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.HasKey(pg => new { pg.UsuarioId, pg.RolId });
            builder.HasOne(pg => pg.Usuario)
                .WithMany(p => p.UsuariosRoles)
                .HasForeignKey(pg => pg.UsuarioId);
            builder.HasOne(pg => pg.Rol)
                .WithMany(g => g.UsuariosRoles)
                .HasForeignKey(pg => pg.RolId);
        }
    }
}
