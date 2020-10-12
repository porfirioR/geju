﻿using GeJu.Api.Main.DTO.Users;
using GeJu.Common;
using System;

namespace GeJu.Api.Main.Test.Admin
{
    internal static class Mother
    {
        public static CreateUserDTO NewUserObject => new CreateUserDTO
        {
            Country = Country.Paraguay,
            CreationDate = DateTime.Now,
            Birthdate = DateTime.Now,
            Email = "prueba@prueba.com",
            LastActive = DateTime.Now,
            LastName = "Prueba",
            Name = "Prueba",
            Active = true
        };

    }
}
