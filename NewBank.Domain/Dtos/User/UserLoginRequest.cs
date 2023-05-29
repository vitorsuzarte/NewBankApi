using System.Runtime.CompilerServices;

namespace NewBank.Domain.Dtos.User
{
    public class UserLoginRequest
    {    
        public string Username { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            if (String.IsNullOrEmpty(Username)) 
                throw new Exception("usuário vazio");
            
            if (String.IsNullOrEmpty(Password)) 
                throw new Exception("senha vazia");
        }
    }
}
