using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Category;
using Api.Domain.Entities.Category;
using AutoMapper;

namespace Api.CrossCutting.Mapper.Category
{
    public class CategoryEntityToDtoProfile : Profile
    {

        public CategoryEntityToDtoProfile()
        {

            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();


            // Dto to Entity
            CreateMap<CategoryCreateDto, CategoryEntity>();

            // Entity to dto
            CreateMap<CategoryEntity, CategoryCreateResultDto>();

        }

    }
}

