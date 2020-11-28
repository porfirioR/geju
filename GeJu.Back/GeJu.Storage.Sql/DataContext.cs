using GeJu.Sql.Configurations;
using GeJu.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeJu.Sql
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuariosRoles { get; set; }
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioRolConfiguracion());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
        }
    }
}
