using NewBank.Domain.Dtos.User;
using NewBank.Domain.Models;

namespace NewBank.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetUser(string username);
        public Task CreateUser(User user);
        public Task AssignToken(string username, string userToken);
        public Task Logout(string username);
        public Task ResetPassword(string username, byte[] passwordHash, byte[] passwordSalt);
    }
}
