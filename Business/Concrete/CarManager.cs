using AutoMapper;
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
        private IMapper _mapper;
        public CarManager(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        public void CreateCar(CarDtoForCreate carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            _carDal.Add(car);
        }

        public IEnumerable<CarDetailDto> GetCars()
        {
            var result = _carDal.GetCarsDetails().ToList();
            return result;
        }

        public IEnumerable<CarDetailDto> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetCarsDetails(s=>s.BrandId == brandId).ToList();
            return result;
        }

        public CarDetailDto GetCar(int carId)
        {
            var result = _carDal.GetCarDetail(s=> s.Id == carId);
            return result;
        }


    }
}