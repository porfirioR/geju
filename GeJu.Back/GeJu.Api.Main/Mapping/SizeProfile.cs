using AutoMapper;
using GeJu.Api.Main.DTO.Sizes;
using GeJu.DALModels.Sizes;
using System;

namespace GeJu.Api.Main.Mapping
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSizeDTO, CreateSize>();
            
            CreateMap<UpdateSizeDTO, UpdateSize>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid(src.Id)));
            
            CreateMap<Size, SizeApi>();
        }
    }
}
