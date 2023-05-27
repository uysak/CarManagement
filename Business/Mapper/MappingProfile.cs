using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDtoForCreate, Car>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
    .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.BrandId))
    .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
    .ForMember(dest => dest.ModelYear, opt => opt.MapFrom(src => src.ModelYear))
    .ForMember(dest => dest.Brand, opt => opt.Ignore());

        }
    }
}
