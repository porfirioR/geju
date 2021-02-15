using GeJu.Common.Enums;
using System;

namespace GeJu.DALModels.Users
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastActive { get; set; }
        public CountryType Country { get; set; }
    }
}
