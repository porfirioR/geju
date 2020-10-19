using System;

namespace AccessServicesModel.Users
{
    public class UpdateUser : CreateUser
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
