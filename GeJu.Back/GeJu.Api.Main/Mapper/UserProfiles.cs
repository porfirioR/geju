using AutoMapper;
using Intermedio.Users;
using GeJu.Api.Main.DTO.Users;

namespace GeJu.Api.Main.Mapper
{
    public class UserProfiles: Profile
    {
        public UserProfiles()
        {
            CreateMap<ActualizarUsuario, ActualizarUsuarioDTO>().ReverseMap();
            CreateMap<CrearUsuario, CrearUsuarioDTO>().ReverseMap();
        }
    }
}
