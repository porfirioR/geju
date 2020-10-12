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
        Task CreateAsync(CreateUser command);
        Task<bool> UpdateAsync(UpdateUser command);
        void Delete(string id);
    }
}
