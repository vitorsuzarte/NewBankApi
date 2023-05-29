using NewBank.Domain.Dtos.User;
using NewBank.Domain.Models;

namespace NewBank.Domain.Mappers
{
    public static class UserMapper
    {
        public static UserResponse ToUserResponse(this User user) => 
            new UserResponse()
            {
                Firstame = user.FirstName,
                LastName = user.LastName,
                UserToken = user.UserToken,
                Balance = user.Balance,
            };


        public static User ToUser(this UserRegisterRequest request) =>
            new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Cpf = request.Cpf,
                Username = request.Username,
                Email = request.Email,
                Phone = request.Phone
            };
    }
}
