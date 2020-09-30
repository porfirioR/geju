using GeJu.Storage.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GeJu.Storage.Sql.Configurations
{
    internal class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            throw new NotImplementedException();
        }
    }
    internal class UsuarioRolConfiguracion : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
        {
            throw new NotImplementedException();

            //builder.HasOne(pg => pg.Usuario)
            //    .WithMany(p => p.UsuariosRoles)
            //    .HasForeignKey(pg => pg.UsuarioId);
            //builder.HasOne(pg => pg.Rol)
            //    .WithMany(g => g.UsuariosRoles)
            //    .HasForeignKey(pg => pg.RolId);
            //builder.HasKey(pg => new { pg.UsuarioId, pg.RolId });
        }
    }
}
