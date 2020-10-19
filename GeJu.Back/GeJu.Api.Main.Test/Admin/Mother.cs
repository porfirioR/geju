using GeJu.Common;
using GeJu.Common.DTO.User;
using System;

namespace GeJu.Api.Main.Test.Admin
{
    internal static class Mother
    {
        public static CreateUserDTO NewUserObject => new CreateUserDTO
        {
            //Country = Country.Paraguay,
            Birthdate = DateTime.Now,
            Email = "prueba@prueba.com",
            LastActive = DateTime.Now,
            LastName = "Prueba",
            Name = "Prueba",
            Active = true
        };

    }
}
