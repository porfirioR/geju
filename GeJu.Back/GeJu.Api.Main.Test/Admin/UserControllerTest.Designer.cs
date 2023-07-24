using GeJu.Common;
using GeJu.Common.DTO.Users;

namespace GeJu.Api.Main.Test.Admin
{
    internal partial class UserControllerTest
    {
        public static CreateUserDTO NewUser => new CreateUserDTO
        {
            Name = "Prueba",
            LastName = "Prueba",
            Email = "prueba@prueba.com",
            Country = Country.Paraguay,
            Birthdate = DateTime.Now,
        };

        public static UpdateUserDTO UpdateUser => new UpdateUserDTO
        {
            Name = "PruebaEdicion",
            LastName = "Prueba",
            Email = "prueba@prueba.com",
            Country = Country.Paraguay,
            Birthdate = DateTime.Now,
        };
    }
}
