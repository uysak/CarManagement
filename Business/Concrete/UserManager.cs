using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<Role>> GetRoles(User user)
        {
            var result = _userDal.GetRoles(user);
            return new SuccessDataResult<List<Role>>(result);
        }


        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(s => s.Email == email);
            

            return result == null ? new ErrorDataResult<User>(result) : new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetByRefreshToken(string refreshToken)
        {
            var result = _userDal.Get(s => s.RefreshToken == refreshToken);

            return result == null ? new ErrorDataResult<User>(result) : new SuccessDataResult<User>(result);
        }
    }
}
