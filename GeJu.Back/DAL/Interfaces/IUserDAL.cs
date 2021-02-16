using GeJu.DALModels.Authentication;
using GeJu.DALModels.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserDAL
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
