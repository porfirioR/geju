using Access.Contract.Admin.Request;
using Access.Contract.Admin.Response;
using AutoMapper;
using GeJu.Sql.Entities;

namespace Admin.Mapping
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionAccess, Permiso>()
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Name));

            CreateMap<Permiso, PermissionAccessResponse>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Active,
                    opt => opt.MapFrom(src => src.Activo))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Descripcion))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Nombre));
        }
    }
}
