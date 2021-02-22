using AutoMapper;
using GeJu.Sql.Entities;

namespace GeJu.Services.Admin.Mapper
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSize, Tamaño>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Code));

            //CreateMap<CreateSizeDTO, CreateSize>();

            //CreateMap<UpdateSizeDTO, UpdateSize>()
            //    .ForMember(dest => dest.Id,
            //        opt => opt.MapFrom(src => new Guid(src.Id)));

            CreateMap<Tamaño, Size>()
                .ForMember(dest => dest.Code,
                    opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
