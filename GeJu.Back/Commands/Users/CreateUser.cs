﻿using GeJu.Utilities.Enums;
using System;

namespace Resources.Contract.Users
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public CountryType Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string Password { get; set; }
    }
}
