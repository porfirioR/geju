using System;

namespace GeJu.Common.DTO.Users
{
    public class UserApi
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastActive { get; set; }
        public Country Country { get; set; }
    }
}
