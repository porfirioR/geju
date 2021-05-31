using Access.Contract.Admin.Request;
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

            CreateMap<UpdateUser, UserAccess>();

            CreateMap<Login, LoginAccess>();

            CreateMap<UserAccessResponse, UserAuth>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src));

            CreateMap<AuthResponse, UserAuth>();
        }
    }
}
