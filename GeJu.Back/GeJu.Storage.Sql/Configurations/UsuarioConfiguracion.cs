using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeJu.Sql.Configurations
{
    internal class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.FechaCreado)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(x => x.FechaModificado)
                .HasDefaultValueSql("GetUtcDate()");
        }
    }

    internal class UsuarioRolConfiguracion : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            builder.HasKey(pg => new { pg.UsuarioId, pg.RolId });

            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.UsuariosRoles)
                .HasForeignKey(x => x.UsuarioId);

            builder.HasOne(x => x.Rol)
                .WithMany(x => x.UsuariosRoles)
                .HasForeignKey(x => x.RolId);
        }
    }
}
