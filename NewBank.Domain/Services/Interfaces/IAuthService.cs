using NewBank.Domain.Models;

namespace NewBank.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        public void CreatePasswordHash(string password, out byte[] passwodHash, out byte[] passwordSalt);
        public bool VerifyPassswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public string CreateToken(User user);

    }
}
