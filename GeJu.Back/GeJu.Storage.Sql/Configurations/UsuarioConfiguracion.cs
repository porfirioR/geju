using GeJu.Storage.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Storage.Sql.Configurations
{
    internal class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
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
