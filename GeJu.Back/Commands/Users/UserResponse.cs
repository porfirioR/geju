using GeJu.Utilities.Enums;
using System;

namespace Resources.Contract.Users
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastActive { get; set; }
        public CountryType Country { get; set; }
    }
}
