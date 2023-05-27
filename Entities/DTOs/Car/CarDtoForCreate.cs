using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.Car
{
    public class CarDtoForCreate
    {

        public int BrandId { get; set; }
        public string Model { get; set; }
        public ushort ModelYear { get; set; }
    
    }
}
