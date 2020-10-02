using Intermedio.Users;
using GeJu.Storage.Sql.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IUsersServices
    {
        Usuario GetUserById(string id);
        IQueryable<Usuario> GetAll();
        Task CreateAsync(CrearUsuario command);
        Task UpdateAsync(ActualizarUsuario command);
        void Delete(string id);
    }
}
