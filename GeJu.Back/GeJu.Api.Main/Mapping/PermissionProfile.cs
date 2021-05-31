using AutoMapper;
using GeJu.Api.Main.Models.Permissions;
using Resources.Contract.Permissions;

namespace GeJu.Api.Main.Mapping
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<UpdatePermissionApiRequest, UpdatePermission>();
            CreateMap<PermissionResponse, PermissionApi>();
        }
    }
}
