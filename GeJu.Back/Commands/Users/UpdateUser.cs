using System;

namespace GeJu.DALModels.Users
{
    public class UpdateUser : CreateUser
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
    }
}
