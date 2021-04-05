using AutoMapper;
using GeJu.Api.Main.Models.Colors;
using Resources.Contract.Colors;

namespace GeJu.Api.Main.Mapping
{
    public class ColorProfile : Profile
    {
        public ColorProfile()
        {
            CreateMap<CreateColorApiRequest, CreateColor>();
            
            CreateMap<UpdateColorApiRequest, UpdateColor>();

            CreateMap<ColorResponse, ColorApi>();
        }
    }
}
