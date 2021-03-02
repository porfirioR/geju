using Access.Contract.Request;
using Access.Contract.Response;
using AutoMapper;
using Resources.Contract.Authentication;
using Resources.Contract.Users;

namespace Manager.Admin.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAccessResponse, UserResponse>();
            
            CreateMap<CreateUser, UserAccess>();

            CreateMap<Login, LoginAccess>();
            
            CreateMap<UserAccessResponse, UserAuth>();

            CreateMap<AuthResponse, UserAuth>();
        }
    }
}
