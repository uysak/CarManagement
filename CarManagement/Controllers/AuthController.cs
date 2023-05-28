using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("Login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateTokens(userToLogin.Data, Response);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            var result = _authService.CreateTokens(registerResult.Data, Response);
             
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken(string? refreshToken)
        {
            var user = _userService.GetByRefreshToken(refreshToken);

            var _refreshToken = string.Empty;

            if (!user.Success)
                return BadRequest(Messages.InvalidRefreshToken);

            _refreshToken = refreshToken == null ? Request.Cookies["RefreshToken"] : refreshToken;


            if (!user.Data.RefreshToken.Equals(_refreshToken))
            {
                return Unauthorized(Messages.InvalidRefreshToken);
            }
            else if (user.Data.TokenExpire < DateTime.Now)
            {
                return Unauthorized(Messages.TokenExpired);
            }

            var result = _authService.CreateTokens(user.Data, Response);  // it contains refresh token and access token 

            if (result.Success)
            {
                return Content(result.Data.ToString(), "application/json");
            }
            return BadRequest(result.Message);
        }

    }
}
