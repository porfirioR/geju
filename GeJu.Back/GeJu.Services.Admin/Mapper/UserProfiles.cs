using AutoMapper;
using Commands.Users;
using GeJu.Storage.Sql.Entities;

namespace GeJu.Services.Admin.Mapper
{
    public class UserProfiles: Profile
    {
        public UserProfiles()
        {
            CreateMap<CreateUserCommand, Usuario>();
            CreateMap<Usuario, UpdateUserCommand>().ReverseMap();
        }
    }
}
