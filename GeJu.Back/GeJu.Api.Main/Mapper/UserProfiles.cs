using AutoMapper;
using Commands.Users;
using GeJu.Api.Main.DTO.Users;

namespace GeJu.Api.Main.Mapper
{
    public class UserProfiles: Profile
    {
        public UserProfiles()
        {
            CreateMap<UpdateUserCommand, UpdateUserDTO>().ReverseMap();
            CreateMap<CreateUserCommand, CreateUserDTO>().ReverseMap();
        }
    }
}
