using Contract.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contract.Users
{
    public interface IUserManager
    {
        Task<User> Create(CreateUser request);
        Task<User> Update(UpdateUser request);
        IEnumerable<User> GetAll();
        User GetById(string id);
        Task<bool> Delete(string id);
        Task<UserAuth> Register(CreateUser createUser);
        UserAuth Login(Login login);

    }
}
