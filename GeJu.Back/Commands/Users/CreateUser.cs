using GeJu.Common;
using System;

namespace Intermedio.Users
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
        public Country Country { get; set; }
    }
}
