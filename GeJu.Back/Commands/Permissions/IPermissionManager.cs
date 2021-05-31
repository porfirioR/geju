using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resources.Contract.Permissions
{
    public interface IPermissionManager
    {
        Task<IEnumerable<PermissionResponse>> GetAll();
        Task<PermissionResponse> GetById(string id);
        Task<PermissionResponse> Update(UpdatePermission request);
        Task<PermissionResponse> Active(string id);
        Task<PermissionResponse> Delete(string id);
    }
}
