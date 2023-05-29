namespace NewBank.Domain.Dtos.User
{
    public class UserResponse
    {
        public string Firstame { get; set; }
        public string LastName { get; set; }
        public double Balance { get; set; } 
        public string UserToken { get; set; }
    }
}
