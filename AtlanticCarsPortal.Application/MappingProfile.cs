using AtlanticCarsPortal.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticCarsPortal.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Car, CarDecorator>();
            CreateMap<CarDecorator, Car>();
        }
    }
}
