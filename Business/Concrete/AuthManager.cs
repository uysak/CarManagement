using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT.Hashing;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Core.Entities.Concrete;
using Business.Constants;
using Entities.DTOs.User;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null || !userToCheck.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt) == false)
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            var check = _userService.GetByMail(email);

            if (check.Success)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var roles = _userService.GetRoles(user);

            var accessToken = _tokenHelper.CreateToken(user, roles.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<RefreshToken> CreateRefreshToken()
        {
            var refreshToken = _tokenHelper.GenerateRefreshToken();
            return new SuccessDataResult<RefreshToken>(refreshToken);
        }
        public IResult SetRefreshToken(RefreshToken refreshToken, HttpResponse response, User user)
        {
            _tokenHelper.SetRefreshToken(refreshToken, response, user);
            return new SuccessResult();
        }

        public IDataResult<TokenResponse> CreateTokens(User user, HttpResponse response)
        {
            var accessToken = CreateAccessToken(user).Data;
            var refreshToken = _tokenHelper.GenerateRefreshToken();

            _tokenHelper.SetRefreshToken(refreshToken, response, user); // refresh tokken adding cookie

            var tokens = new TokenResponse
            {
                AccessToken = accessToken.Token,
                RefreshToken = refreshToken.Token,
            };

            _userService.Update(user);

            return new SuccessDataResult<TokenResponse>(tokens);

        }


    }
}
