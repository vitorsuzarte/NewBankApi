using Microsoft.VisualBasic;

namespace NewBank.Domain.Dtos.User
{
    public class UserResetPasswordRequest
    {
        public string Username { get; set; }
        public string NewPassword { get; set; }
    }
}
