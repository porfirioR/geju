using Contract.Users;
using GeJu.Sql.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Interfaces
{
    public interface IUserService
    {
        Task<Usuario> CreateAsync(CreateUser command);
        Usuario GetById(string id);
        IQueryable<Usuario> GetAll();
        Task<Usuario> UpdateAsync(UpdateUser command);
        Task<bool> DeleteAsync(string id);
        Task<Usuario> RegisterAsync(CreateUser createUser);
    }
}
