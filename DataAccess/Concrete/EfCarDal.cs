using DataAccess.Abstract;
using DataAccess.Context;
using Entities.Concrete;
using Entities.DTOs.Car;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car>, ICarDal
    {
        public IEnumerable<CarDetailDto> GetCarsDetails(Expression<Func<Car,bool>> filter = null)
        {
            using(var context = new CarsContext())
            {
                var carsList = filter == null ? context.Cars.Include(c => c.Brand).ToList() : context.Cars.Include(c => c.Brand).Where(filter).ToList();

                var carsDetails = carsList.Select(car => new CarDetailDto
                {
                    Id = car.Id,
                    BrandName = car.Brand.Name,
                    BrandWebsiteURL = car.Brand.WebsiteURL,
                    Model = car.Model,
                    ModelYear = car.ModelYear
                });

                return carsDetails;
            }
        }

        public CarDetailDto GetCarDetail(Expression<Func<Car,bool>> filter)
        {
            using (var context = new CarsContext())
            {
                var car = context.Cars.Include(c => c.Brand).Where(filter).SingleOrDefault();

                var carDetail = new CarDetailDto
                {
                    Id = car.Id,
                    BrandName = car.Brand.Name,
                    BrandWebsiteURL = car.Brand.WebsiteURL,
                    Model = car.Model,
                    ModelYear = car.ModelYear
                };

                return carDetail;
            }
        }
    }
}
