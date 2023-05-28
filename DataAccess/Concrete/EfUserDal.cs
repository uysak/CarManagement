using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User>, IUserDal
    {
        public List<Role> GetRoles(User user)
        {
            using (var context = new CarsContext())
            {
                var result = from role in context.Roles
                             join userRole in context.UserRoles
                                 on role.Id equals userRole.RoleId
                             where userRole.UserId == user.Id
                             select new Role { Id = role.Id, Name = role.Name };
                return result.ToList();
            }
        }


    }
}
