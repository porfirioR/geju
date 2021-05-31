using Access.Contract.Admin.Response;
using AutoMapper;
using Resources.Contract.Permissions;

namespace Manager.Admin.Mapping
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<UpdatePermission, PermissionAccessResponse>();
            CreateMap<PermissionAccessResponse, PermissionResponse>();
        }
    }
}
