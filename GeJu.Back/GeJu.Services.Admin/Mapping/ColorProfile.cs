using Access.Contract.Request;
using Access.Contract.Response;
using AutoMapper;
using GeJu.Sql.Entities;
using Resources.Contract.Colors;
using System;

namespace Admin.Mapping
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<ColorAccess, Color>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.Descripcion,
                    opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Codigo,
                    opt => opt.MapFrom(src => src.Code));

            CreateMap<UpdateColor, Color>()
                .ForMember(dest => dest.FechaModificado,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Color, ColorAccessResponse>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Code,
                    opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.Description,
                    opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}
