using Access.Contract.Admin.Request;
using Access.Contract.Admin.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Access.Contract.Admin.Interfaces
{
    public interface IPermissionDataAccess
    {
        Task<IEnumerable<PermissionAccessResponse>> GetAllAsync();
        Task<PermissionAccessResponse> UpdateAsync(PermissionAccess request);
        Task<PermissionAccessResponse> DeleteAsync(string id);
        Task<PermissionAccessResponse> ActivateAsync(string id);
        Task<PermissionAccessResponse> GetByIdAsync(string id);
    }
}
