using Commands.Users;
using GeJu.Storage.Sql.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace GeJu.Services.Admin.Interfaces
{
    public interface IUsersServices
    {
        User GetUserById(string id);
        IQueryable<User> GetAll();
        Task CreateAsync(CreateUserCommand command);
        Task UpdateAsync(UpdateUserCommand command);
        void Delete(string id);
    }
}
