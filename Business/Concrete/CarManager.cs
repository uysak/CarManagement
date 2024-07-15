using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.Car;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private IBrandDal _brandDal;

        private IMapper _mapper;
        public CarManager(ICarDal carDal,IBrandDal brandDal, IMapper mapper)
        {
            _carDal = carDal;
            _brandDal = brandDal;
            _mapper = mapper;
        }

        public IResult CreateCar(CarDtoForCreate carDto)
        {
            var check = BusinessRules.Run(CheckIfBrandExist(carDto.BrandId),CheckIfCarModelNotExist(carDto.Model));

            if(check != null && check.Success == false)
            {
                return new ErrorResult(Messages.BrandNotExists);
            }
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

        public IResult CheckIfBrandExist(int brandId)
        {
            var brandCheck = _brandDal.Get(b=>b.Id == brandId);
            if(brandCheck != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult CheckIfCarModelNotExist(string model)
        {
            var modelCheck = _carDal.Get(c=>c.Model == model);

            if (modelCheck == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


    }
}