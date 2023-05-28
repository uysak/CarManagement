using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public int BrandId { get; set; }
        

        [Required]
        [StringLength(30)]
        public string Model { get; set; }

        [Required]
        [Column(TypeName = "smallint")]
        public ushort ModelYear { get; set; }


        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

    }
}
