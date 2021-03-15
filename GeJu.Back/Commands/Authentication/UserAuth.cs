using Resources.Contract.Users;

namespace Resources.Contract.Authentication
{
    public class UserAuth
    {
        public UserResponse User { get; set; }
        public string Token { get; set; }
    }
}
