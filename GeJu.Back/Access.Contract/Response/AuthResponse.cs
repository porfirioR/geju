namespace Access.Contract.Response
{
    public class AuthResponse
    {
        public UserAccessResponse User { get; set; }
        public string Token { get; set; }
    }
}
