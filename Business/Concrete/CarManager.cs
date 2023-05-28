using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult CreateCar(CarDtoForCreate carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            _carDal.Add(car);
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetCars()
        {
            var result = _carDal.GetCarsDetails().ToList();
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetCarsDetails(s=>s.BrandId == brandId).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<CarDetailDto> GetCar(int carId)
        {
            var result = _carDal.GetCarDetail(s=> s.Id == carId);
            return new SuccessDataResult<CarDetailDto>(result);
        }
    }
}