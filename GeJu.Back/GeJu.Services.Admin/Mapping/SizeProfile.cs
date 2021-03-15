using Access.Contract.Request;
using AutoMapper;
using GeJu.Sql.Entities;
using Resources.Contract.Sizes;

namespace Admin.Mapping
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<SizeAccess, Tamaño>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Code));

            CreateMap<Tamaño, SizeResponse>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Code,
                    opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
