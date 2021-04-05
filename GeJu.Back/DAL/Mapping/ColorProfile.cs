using Access.Contract.Request;
using Access.Contract.Response;
using AutoMapper;
using Resources.Contract.Colors;

namespace Manager.Admin.Mapping
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<CreateColor, ColorAccess>()
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));

            CreateMap<UpdateColor, ColorAccess>()
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true));

            CreateMap<ColorAccessResponse, ColorResponse>();
        }
    }
}
