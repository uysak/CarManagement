using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IDataResult<List<Role>> GetRoles(User user);
        public IResult Add(User user);
        public IResult Update(User user);
        public IDataResult<User> GetByMail(string email);
        public IDataResult<User> GetByRefreshToken(string refreshToken);
    }
}
