using Access.Contract.Admin.Interfaces;
using Access.Contract.Admin.Request;
using AutoMapper;
using Resources.Contract.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Admin
{
    internal class PermissionManager : IPermissionManager
    {
        private readonly IMapper _mapper;
        private readonly IPermissionDataAccess _permissionDataAccess;

        public PermissionManager(IMapper mapper, IPermissionDataAccess permissionDataAccess)
        {
            _mapper = mapper;
            _permissionDataAccess = permissionDataAccess;
        }

        public async Task<IEnumerable<PermissionResponse>> GetAll()
        {
            var accessResponse = await _permissionDataAccess.GetAllAsync();
            var response = _mapper.Map<IEnumerable<PermissionResponse>>(accessResponse);
            return response;
        }

        public async Task<PermissionResponse> GetById(string id)
        {
            var accessResponse = await _permissionDataAccess.GetByIdAsync(id);
            var response = _mapper.Map<PermissionResponse>(accessResponse);
            return response;
        }

        public async Task<PermissionResponse> Update(UpdatePermission request)
        {
            var requestDataAccess = _mapper.Map<PermissionAccess>(request);
            var entity = await _permissionDataAccess.UpdateAsync(requestDataAccess);
            var response = _mapper.Map<PermissionResponse>(entity);
            return response;
        }

        public async Task<PermissionResponse> Active(string id)
        {
            var accessResponse = await _permissionDataAccess.ActivateAsync(id);
            var response = _mapper.Map<PermissionResponse>(accessResponse);
            return response;
        }

        public async Task<PermissionResponse> Delete(string id)
        {
            var accessResponse = await _permissionDataAccess.DeleteAsync(id);
            var response = _mapper.Map<PermissionResponse>(accessResponse);
            return response;
        }

    }
}
