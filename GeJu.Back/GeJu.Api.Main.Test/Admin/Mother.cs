using GeJu.Api.Main.Models.Users;
using GeJu.Utilities.Enums;
using System;

namespace GeJu.Api.Main.Test.Admin
{
    internal static class Mother
    {
        public static CreateUserApiRequest NewUser => new CreateUserApiRequest
        {
            Name = "Prueba",
            LastName = "Prueba",
            Email = "prueba@prueba.com",
            Country = CountryType.Paraguay,
            Birthdate = DateTime.Now,
        };

        public static UpdateUserApiRequest UpdateUser => new UpdateUserApiRequest
        {
            Name = "PruebaEdicion",
            LastName = "Prueba",
            Email = "prueba@prueba.com",
            Country = CountryType.Paraguay,
            Birthdate = DateTime.Now,
        };
    }
}
