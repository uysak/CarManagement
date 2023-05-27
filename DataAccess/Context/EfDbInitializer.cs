using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccess.Context
{
    public class EfDbInitializer
    {
        public static void Migrate(CarsContext db)
        {
            db.Database.Migrate();
        }

        public static void Initialize(CarsContext db)
        {
            AddDefaultBrands(db);
            AddDefaultCars(db);
        }

        public static void AddDefaultBrands(CarsContext db)
        {
            if(db.Brands.Any())
            {
                return;
            }

            db.Brands.Add(new Brand
            {
                Id= 1,
                Name = "Mercedes",
                WebsiteURL = "https://www.mercedes-benz.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 2,
                Name = "Opel",
                WebsiteURL = "https://www.opel.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 3,
                Name = "Fiat",
                WebsiteURL = "https://www.fiat.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 4,
                Name = "Toyota",
                WebsiteURL = "https://www.toyota.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 5,
                Name = "Honda",
                WebsiteURL = "https://www.honda.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 6,
                Name = "Volkswagen",
                WebsiteURL = "https://www.vw.com",
            });

            db.Brands.Add(new Brand
            {
                Id = 7,
                Name = "Ford",
                WebsiteURL = "https://www.ford.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 8,
                Name = "Hyundai",
                WebsiteURL = "https://www.hyundai.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 9,
                Name = "Nissan",
                WebsiteURL = "https://www.nissan-global.com"
            });

            db.Brands.Add(new Brand
            {
                Id = 10,
                Name = "Chevrolet",
                WebsiteURL = "https://www.chevrolet.com"
            });

            db.SaveChanges();
        }

        public static void AddDefaultCars(CarsContext db)
        {
            if (db.Cars.Any())
            {
                return;
            }

            // Mercedes
            db.Cars.Add(new Car
            {
                Id = 1,
                BrandId = 1,
                Model = "A180",
                ModelYear = 2012
            });

            db.Cars.Add(new Car
            {
                Id = 2,
                BrandId = 1,
                Model = "C200",
                ModelYear = 2015
            });

            db.Cars.Add(new Car
            {
                Id = 3,
                BrandId = 1,
                Model = "E350",
                ModelYear = 2018
            });

            // Opel
            db.Cars.Add(new Car
            {
                Id = 4,
                BrandId = 2,
                Model = "Corsa",
                ModelYear = 2010
            });

            db.Cars.Add(new Car
            {
                Id = 5,
                BrandId = 2,
                Model = "Astra",
                ModelYear = 2014
            });

            db.Cars.Add(new Car
            {
                Id = 6,
                BrandId = 2,
                Model = "Insignia",
                ModelYear = 2017
            });

            // Fiat
            db.Cars.Add(new Car
            {
                Id = 7,
                BrandId = 3,
                Model = "Punto",
                ModelYear = 2011
            });

            db.Cars.Add(new Car
            {
                Id = 8,
                BrandId = 3,
                Model = "500",
                ModelYear = 2015
            });

            db.Cars.Add(new Car
            {
                Id = 9,
                BrandId = 3,
                Model = "Tipo",
                ModelYear = 2019
            });

            // Toyota
            db.Cars.Add(new Car
            {
                Id = 10,
                BrandId = 4,
                Model = "Corolla",
                ModelYear = 2013
            });

            db.Cars.Add(new Car
            {
                Id = 11,
                BrandId = 4,
                Model = "Camry",
                ModelYear = 2016
            });

            db.Cars.Add(new Car
            {
                Id = 12,
                BrandId = 4,
                Model = "RAV4",
                ModelYear = 2019
            });

            // Honda
            db.Cars.Add(new Car
            {
                Id = 13,
                BrandId = 5,
                Model = "Civic",
                ModelYear = 2012
            });

            db.Cars.Add(new Car
            {
                Id = 14,
                BrandId = 5,
                Model = "Accord",
                ModelYear = 2015
            });

            db.Cars.Add(new Car
            {
                Id = 15,
                BrandId = 5,
                Model = "CR-V",
                ModelYear = 2018
            });

            // Volkswagen
            db.Cars.Add(new Car
            {
                Id = 16,
                BrandId = 6,
                Model = "Golf",
                ModelYear = 2011
            });

            db.Cars.Add(new Car
            {
                Id = 17,
                BrandId = 6,
                Model = "Passat",
                ModelYear = 2014
            });

            db.Cars.Add(new Car
            {
                Id = 18,
                BrandId = 6,
                Model = "Tiguan",
                ModelYear = 2017
            });

            // Ford
            db.Cars.Add(new Car
            {
                Id = 19,
                BrandId = 7,
                Model = "Focus",
                ModelYear = 2013
            });

            db.Cars.Add(new Car
            {
                Id = 20,
                BrandId = 7,
                Model = "Fiesta",
                ModelYear = 2016
            });

            db.Cars.Add(new Car
            {
                Id = 21,
                BrandId = 7,
                Model = "Mustang",
                ModelYear = 2019
            });

            // Hyundai
            db.Cars.Add(new Car
            {
                Id = 22,
                BrandId = 8,
                Model = "i10",
                ModelYear = 2012
            });

            db.Cars.Add(new Car
            {
                Id = 23,
                BrandId = 8,
                Model = "i30",
                ModelYear = 2015
            });

            db.Cars.Add(new Car
            {
                Id = 24,
                BrandId = 8,
                Model = "Tucson",
                ModelYear = 2018
            });

            // Nissan
            db.Cars.Add(new Car
            {
                Id = 25,
                BrandId = 9,
                Model = "Micra",
                ModelYear = 2011
            });

            db.Cars.Add(new Car
            {
                Id = 26,
                BrandId = 9,
                Model = "Qashqai",
                ModelYear = 2014
            });

            db.Cars.Add(new Car
            {
                Id = 27,
                BrandId = 9,
                Model = "X-Trail",
                ModelYear = 2017
            });

            // Chevrolet
            db.Cars.Add(new Car
            {
                Id = 28,
                BrandId = 10,
                Model = "Cruze",
                ModelYear = 2012
            });

            db.Cars.Add(new Car
            {
                Id = 29,
                BrandId = 10,
                Model = "Malibu",
                ModelYear = 2015
            });

            db.Cars.Add(new Car
            {
                Id = 30,
                BrandId = 10,
                Model = "Equinox",
                ModelYear = 2018
            });

            db.SaveChanges();
        }
    }
}
