namespace GeJu.AccessServicesModel.Users
{
    public class UpdateUser : CreateUser
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
    }
}
