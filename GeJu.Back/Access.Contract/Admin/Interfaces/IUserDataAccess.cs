using Access.Contract.Admin.Request;
using Access.Contract.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Access.Contract.Admin.Interfaces
{
    public interface IUserDataAccess
    {
        Task<UserAccessResponse> CreateAsync(UserAccess model);
        Task<UserAccessResponse> GetByIdAsync(string id);
        Task<IEnumerable<UserAccessResponse>> GetAllAsync();
        Task<UserAccessResponse> UpdateAsync(UserAccess model);
        Task<UserAccessResponse> DeleteAsync(string id);
        Task<UserAccessResponse> RegisterAsync(UserAccess model);
    }
}
