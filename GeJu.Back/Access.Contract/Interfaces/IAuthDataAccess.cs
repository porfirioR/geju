using Access.Contract.Request;
using Access.Contract.Response;
using System.Threading.Tasks;

namespace Admin.Interfaces
{
    public interface IAuthDataAccess
    {
        string CreateToken(UserAccess model);
        Task<AuthResponse> Login(LoginAccess loginAccess);
    }
}
