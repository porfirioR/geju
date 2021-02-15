using GeJu.Common.DTO.Users;
using GeJu.Common.Enums;
using System;

namespace GeJu.Api.Main.Test.Admin
{
    internal static class Mother
    {
        public static CreateUserDTO NewUser => new CreateUserDTO
        {
            Name = "Prueba",
            LastName = "Prueba",
            Email = "prueba@prueba.com",
            Country = CountryType.Paraguay,
            Birthdate = DateTime.Now,
        };

        public static UpdateUserDTO UpdateUser => new UpdateUserDTO
        {
            Name = "PruebaEdicion",
            LastName = "Prueba",
            Email = "prueba@prueba.com",
            Country = CountryType.Paraguay,
            Birthdate = DateTime.Now,
        };
    }
}
