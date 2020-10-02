using AutoMapper;
using Intermedio.Users;
using GeJu.Storage.Sql.Entities;

namespace GeJu.Services.Admin.Mapper
{
    public class UserProfiles: Profile
    {
        public UserProfiles()
        {
            CreateMap<CrearUsuario, Usuario>();
            CreateMap<Usuario, ActualizarUsuario>().ReverseMap();
        }
    }
}
