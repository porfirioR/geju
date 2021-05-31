using Access.Contract.Admin.Request;
using Access.Contract.Response;
using AutoMapper;
using GeJu.Sql.Entities;
using System;

namespace Admin.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserAccess, Usuario>()
                .ForMember(dest => dest.Activo,
                    opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Nombre,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Apellido,
                    opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Correo,
                    opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Documento,
                    opt => opt.MapFrom(src => src.Document))
                .ForMember(dest => dest.FechaNaciento,
                    opt => opt.MapFrom(src => src.Birthdate))
                .ForMember(dest => dest.UltimoInicio,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Pais,
                    opt => opt.MapFrom(src => src.Country));

            CreateMap<Usuario, UserAccessResponse>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.LastName,
                    opt => opt.MapFrom(src => src.Apellido))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Correo))
                .ForMember(dest => dest.Document,
                    opt => opt.MapFrom(src => src.Documento))
                .ForMember(dest => dest.Birthdate,
                    opt => opt.MapFrom(src => src.FechaNaciento))
                .ForMember(dest => dest.LastActive,
                    opt => opt.MapFrom(src => src.UltimoInicio))
                .ForMember(dest => dest.Country,
                    opt => opt.MapFrom(src => src.Pais));

            CreateMap<Usuario, AuthResponse>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src));
        }
    }
}
