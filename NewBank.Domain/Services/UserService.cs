using Microsoft.AspNetCore.Mvc;
using NewBank.Domain.Dtos.User;
using NewBank.Domain.Mappers;
using NewBank.Domain.Models;
using NewBank.Domain.Repositories;
using NewBank.Domain.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace NewBank.Domain.Services
{
    public class UserService : IUserService
    {

        public IAuthService _authService { get; set; }
        public IUserRepository _userRepository { get; set; }
        
        public UserService(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Login(UserLoginRequest request)
        {
            var user = await _userRepository.GetUser(request.Username);

            if (user is null)
            {
                throw new Exception("Usuário não encontrado!");
            }

            if (!_authService.VerifyPassswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("Senha incorreta!");
            }

            try
            {
                var userToken = _authService.CreateToken(user);
                await _userRepository.AssignToken(request.Username, userToken);
                user.UserToken = userToken;
                return user.ToUserResponse();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserResponse> Register(UserRegisterRequest request)
        {
            try
            {
                request.Validate();

                _authService.CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalet);
                
                var user = request.ToUser();
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalet;
                user.Balance = 0;
                user.UserToken = _authService.CreateToken(user);

                await _userRepository.CreateUser(user);

                return user.ToUserResponse() ;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Logout(string username)
        {
            //validar a request aqui

            var user = await _userRepository.GetUser(username);

            if(user is null)
                throw new Exception("Usuário não encontrado!");

            if (String.IsNullOrEmpty(user.UserToken))
                throw new Exception("Usuário não está logado!");

            await _userRepository.Logout(username);

        }

        public async Task ResetPassword(UserResetPasswordRequest request)
        {
            //validar a request aqui

            var user = await _userRepository.GetUser(request.Username);

            if (user is null)
                throw new Exception("Usuário não encontrado!");

            _authService.CreatePasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalet);

            await _userRepository.ResetPassword(request.Username, passwordHash, passwordSalet);
        }
    }
}
