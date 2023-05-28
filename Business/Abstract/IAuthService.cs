using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using Entities.DTOs.User;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        public IDataResult<TokenResponse> CreateTokens(User user, HttpResponse response);
        IResult SetRefreshToken(RefreshToken refreshToken, HttpResponse response, User user);
        IDataResult<RefreshToken> CreateRefreshToken();
    }
}
