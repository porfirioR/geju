using GeJu.Api.Main.DTO.Users;
using GeJu.Common;
using System;

namespace GeJu.Api.Main.Test.Admin
{
    internal static class Mother
    {
        public static CrearUsuarioDTO NewUserObject => new CrearUsuarioDTO
        {
            Pais = Country.Paraguay,
            Genero = Gender.Masculino,
            FechaCreado = DateTime.Now,
            FechaNaciento = DateTime.Now,
            Correo = "prueba@prueba.com",
            LastActive = DateTime.Now,
            Apellido = "Prueba",
            Nombre = "Prueba",
            Activo = true
        };

    }
}
