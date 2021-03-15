using AutoMapper;
using GeJu.Api.Main.Models.Sizes;
using Resources.Contract.Sizes;

namespace GeJu.Api.Main.Mapping
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSizeApiRequest, CreateSize>();
            
            CreateMap<UpdateSizeApiRequest, UpdateSize>();
            
            CreateMap<SizeResponse, SizeApi>();
        }
    }
}
