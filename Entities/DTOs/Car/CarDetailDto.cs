using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Car
{
    public class CarDetailDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public ushort ModelYear { get; set; }
        public string BrandName { get; set; }
        public string BrandWebsiteURL { get; set; }
    }

}
