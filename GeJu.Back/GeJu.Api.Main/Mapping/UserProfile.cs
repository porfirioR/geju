using AutoMapper;
using Contract.Users;
using GeJu.Api.Main.Models.Users;

namespace GeJu.Api.Main.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserApiRequest, CreateUser>();
            CreateMap<UpdateUserApiRequest, UpdateUser>();
            
            CreateMap<User, UserApi>();
        }
    }
}
