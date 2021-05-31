using GeJu.Sql.Configurations;
using GeJu.Sql.Entities;
using GeJu.Storage.Sql.Configurations;
using Microsoft.EntityFrameworkCore;
using Sql.Configurations;

namespace GeJu.Sql
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolPermisos { get; set; }
        public DbSet<UsuarioRol> UsuariosRoles { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Tamaño> Tamaños { get; set; }
        public DbSet<ProductoTamaño> ProductoTamaños { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<ProductoColor> ProductosColores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioRolConfiguracion());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoConfiguracion());
            modelBuilder.ApplyConfiguration(new ProductoTamañoConfiguracion());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductoColorConfiguracion());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        }
    }
}
