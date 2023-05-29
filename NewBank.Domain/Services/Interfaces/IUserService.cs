using NewBank.Domain.Dtos.User;

namespace NewBank.Domain.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserResponse> Login(UserLoginRequest request);
        public Task<UserResponse> Register(UserRegisterRequest request);
        public Task Logout(string username);
        public Task ResetPassword(UserResetPasswordRequest request);
    }
}
