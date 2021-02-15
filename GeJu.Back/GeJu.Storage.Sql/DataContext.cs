using GeJu.Sql.Configurations;
using GeJu.Sql.Entities;
using GeJu.Storage.Sql.Configurations;
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
        public DbSet<Tamaño> Tamaños { get; set; }
        public DbSet<ProductoTamaño> ProductoTamaños { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRolConfiguracion());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductoConfiguracion());
            modelBuilder.ApplyConfiguration(new ProductoTamañoConfiguracion());
        }
    }
}
