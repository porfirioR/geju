using Resources.Contract.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.Contract.Users
{
    public interface IUserManager
    {
        Task<UserResponse> Create(CreateUser request);
        Task<UserResponse> Update(UpdateUser request);
        Task<IEnumerable<UserResponse>> GetAll();
        Task<UserResponse> GetById(string id);
        Task<UserResponse> Delete(string id);
        Task<UserAuth> Register(CreateUser createUser);
        Task<UserAuth> Login(Login login);
    }
}
