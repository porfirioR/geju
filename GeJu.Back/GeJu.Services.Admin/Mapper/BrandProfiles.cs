using AutoMapper;
using GeJu.AccessServicesModel.Brands;
using GeJu.Common.DTO.Brands;
using GeJu.Sql.Entities;
using System;

namespace GeJu.Services.Admin.Mapper
{
    public class BrandProfiles : Profile
    {
        public BrandProfiles()
        {
            CreateMap<CreateBrand, Marca>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Name));

            CreateMap<UpdateBrand, Marca>()
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.FechaModificado, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<CreateBrandDTO, CreateBrand>();
            CreateMap<UpdateBrandDTO, UpdateBrand>().ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => new Guid(src.Id)));
            CreateMap<Marca, BrandApi>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
