using GeJu.Common;

namespace GeJu.AccessServicesModel.Users
{
    public class CreateUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public Country Country { get; set; }
    }
}
