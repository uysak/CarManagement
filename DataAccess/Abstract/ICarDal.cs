﻿using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        public IEnumerable<CarDetailDto> GetCarsDetails(Expression<Func<Car, bool>> filter = null);
        public CarDetailDto GetCarDetail(Expression<Func<Car, bool>> filter);

    }
}
