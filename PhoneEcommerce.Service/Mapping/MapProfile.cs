﻿using AutoMapper;
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
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, BrandWithModelsDto>().ReverseMap();
            
            CreateMap<Model, ModelDto>().ReverseMap();
            CreateMap<Model, CreateModelDto>().ReverseMap();
            CreateMap<Model, ModelWithVersionsDto>().ReverseMap();
            CreateMap<Model, UpdateModelDto>().ReverseMap();

            CreateMap<Core.Model.Version, VersionDto>().ReverseMap();
            CreateMap<Core.Model.Version, CreateVersionDto>().ReverseMap();
            CreateMap<Core.Model.Version, UpdateVersionDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
            CreateMap<Order, OrderWithOrderItemsDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerWithOrdersDto>().ReverseMap();
        }
    }
}
