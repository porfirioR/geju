using GeJu.Storage.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeJu.Storage.Sql
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Rol> Roles { get; set; }
        //public DbSet<UsuarioRol> UsuariosRoles { get; set; }
    }
}
