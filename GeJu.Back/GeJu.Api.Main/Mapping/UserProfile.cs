using AutoMapper;
using GeJu.Common.DTO.Users;
using GeJu.DALModels.Users;

namespace GeJu.Api.Main.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, CreateUser>();
            CreateMap<UpdateUserDTO, UpdateUser>();
            
            CreateMap<User, UserApi>();
        }
    }
}
