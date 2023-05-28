using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        public AccessToken CreateToken(User user, List<Role> roles);
        public RefreshToken GenerateRefreshToken();
        public void SetRefreshToken(RefreshToken token, HttpResponse response, User user); //Http Response for access cookie

    }
}
