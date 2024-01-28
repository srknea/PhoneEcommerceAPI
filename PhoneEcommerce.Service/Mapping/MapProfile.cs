using AutoMapper;
using PhoneEcommerce.Core.DTOs;
using PhoneEcommerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneEcommerce.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Brand, BrandDto>().ReverseMap();
        }
    }
}
