using AutoMapper;
using GeJu.Api.Main.Models.Authentication;
using Resources.Contract.Authentication;

namespace GeJu.Api.Main.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginApiRequest, Login>();

            CreateMap<UserAuth, UserAuthApi>();
        }
    }
}
