using AutoMapper;
using GeJu.AccessServicesModel.Sizes;
using GeJu.Common.DTO.Size;
using GeJu.Sql.Entities;
using System;

namespace GeJu.Services.Admin.Mapper
{
    public class SizeProfiles : Profile
    {
        public SizeProfiles()
        {
            CreateMap<CreateSize, Tamaño>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Code));

            CreateMap<CreateSizeDTO, CreateSize>();

            CreateMap<UpdateSizeDTO, UpdateSize>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => new Guid(src.Id)));

            CreateMap<Tamaño, SizeApi>()
                .ForMember(dest => dest.Code,
                    opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
