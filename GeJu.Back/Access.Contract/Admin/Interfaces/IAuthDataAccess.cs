using Access.Contract.Admin.Request;
using Access.Contract.Response;
using System.Threading.Tasks;

namespace Access.Contract.Admin.Interfaces
{
    public interface IAuthDataAccess
    {
        string CreateToken(string name);
        Task<AuthResponse> Login(LoginAccess loginAccess);
    }
}
