using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dto=>dto.Name, source => source.MapFrom(ent=>ent.Name))
                .ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
