using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs.Car;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public IActionResult CreateCar(CarDtoForCreate carDto)
        {
            _carService.CreateCar(carDto);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllCars()
        {
            var result = _carService.GetCars();
            return Ok(result);
        }

        [HttpGet("GetCarsByBrandId")]
        public IActionResult GetByBrandId(int brandId) 
        {
            var result = _carService.GetCarsByBrandId(brandId);
            return Ok(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetCar(int carId)
        {
            var result = _carService.GetCar(carId);
            return Ok(result);
        }
    }
}
