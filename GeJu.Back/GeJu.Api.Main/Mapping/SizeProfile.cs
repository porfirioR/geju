using AutoMapper;
using Contract.Sizes;
using GeJu.Api.Main.Models.Sizes;
using System;

namespace GeJu.Api.Main.Mapping
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSizeApiRequest, CreateSize>();
            
            CreateMap<UpdateSizeApiRequest, UpdateSize>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new Guid(src.Id)));
            
            CreateMap<Size, SizeApi>();
        }
    }
}
