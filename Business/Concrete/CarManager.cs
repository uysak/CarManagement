using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void CreateCar(Car car)
        {
            _carDal.Add(car);
        }

        public IEnumerable<CarDetailDto> GetCars()
        {
            var result = _carDal.GetCarsDetails().ToList();
            return result;
        }

        public CarDetailDto GetCar(int carId)
        {
            var result = _carDal.GetCarDetail(carId);
            return result;
        }


    }
}
