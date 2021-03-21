using Access.Contract.Request;
using Access.Contract.Response;
using AutoMapper;
using Resources.Contract.Sizes;

namespace Manager.Admin.Mapping
{
    public class SizeProfile : Profile
    {
        public SizeProfile()
        {
            CreateMap<CreateSize, SizeAccess>();

            CreateMap<UpdateSize, SizeAccess>();
            
            CreateMap<SizeAccessResponse, SizeResponse>();

        }
    }
}
