using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        public void CreateCar(CarDtoForCreate carDto);
        public IEnumerable<CarDetailDto> GetCars();
        public IEnumerable<CarDetailDto> GetCarsByBrandId(int brandId);
        public CarDetailDto GetCar(int carId);
    }
}
