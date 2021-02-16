using AutoMapper;
using GeJu.Common.DTO.Authentication;
using GeJu.DALModels.Authentication;

namespace GeJu.Api.Main.Mapping
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginDTO, Login>();

            CreateMap<UserAuth, UserAuthApi>();
        }
    }
}
