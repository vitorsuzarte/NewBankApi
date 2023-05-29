using Microsoft.AspNetCore.Mvc;
using NewBank.Domain.Dtos.User;
using NewBank.Domain.Models;
using NewBank.Domain.Services.Interfaces;

namespace NewBank.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterRequest request)
        {
            try
            {
                var result = await _userService.Register(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLoginRequest request)
        {
            try
            {
                var result = await _userService.Login(request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<ActionResult<string>> Logout(string username)
        {
            try
            {
                await _userService.Logout(username);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("resetPassword")]
        public async Task<ActionResult<string>> ResetPassword(UserResetPasswordRequest request)
        {
            try
            {
                await _userService.ResetPassword(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
