using Core.Utilities.Results;
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
        public IResult CreateCar(CarDtoForCreate carDto);
        public IDataResult<List<CarDetailDto>> GetCars();
        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        public IDataResult<CarDetailDto> GetCar(int carId);
    }
}
