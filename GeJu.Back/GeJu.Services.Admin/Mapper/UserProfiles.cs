using AutoMapper;
using GeJu.AccessServicesModel.Users;
using GeJu.Common.DTO.Users;
using GeJu.Sql.Entities;

namespace GeJu.Services.Admin.Mapper
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<CreateUser, Usuario>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Apellido,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Correo,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FechaNaciento,
                    opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.UltimoInicio,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Pais,
                    opt => opt.MapFrom(src => src.Country));

            CreateMap<UpdateUser, Usuario>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Apellido,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Correo,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FechaNaciento,
                    opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.UltimoInicio,
                    opt => opt.MapFrom(src => src.LastActive))
                .ForMember(dest => dest.Pais,
                    opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.FechaModificado,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateUserDTO, UpdateUser>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => new Guid(src.Id)));
            CreateMap<CreateUserDTO, CreateUser>();

            CreateMap<Usuario, UserApi>()
                .ForMember(dest => dest.Active,
                    opt => opt.MapFrom(src => src.Activo))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Birthdate,
                    opt => opt.MapFrom(src => src.FechaNaciento))
                .ForMember(dest => dest.CreationDate,
                    opt => opt.MapFrom(src => src.FechaCreado))
                .ForMember(dest => dest.LastActive,
                    opt => opt.MapFrom(src => src.UltimoInicio))
                .ForMember(dest => dest.Country,
                    opt => opt.MapFrom(src => src.Pais));

        }
    }
}
