using AutoMapper;
using GeJu.Api.Main.Models.Users;
using Resources.Contract.Users;

namespace GeJu.Api.Main.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserApiRequest, CreateUser>();

            CreateMap<UpdateUserApiRequest, UpdateUser>();
            
            CreateMap<UserResponse, UserApi>();
        }
    }
}
