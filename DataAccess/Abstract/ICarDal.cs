using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        public IEnumerable<CarDetailDto> GetCarsDetails();
        public CarDetailDto GetCarDetail(int carId);
    }
}
