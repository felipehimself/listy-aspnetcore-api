using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.List;
using Api.Domain.Entities.List;
using AutoMapper;

namespace Api.CrossCutting.Mapper.List
{
    public class ListEntityToDtoProfile : Profile
    {
        public ListEntityToDtoProfile()
        {

            CreateMap<ListItemEntity, ListItemCreateDto>()
                     .ReverseMap();

        //    CreateMap<ListEntity, ListCreateDto>()
        //         .ReverseMap();


            CreateMap<ListEntity, ListCreateDto>()
                    // .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                    // .ForMember(dest => dest.ListItems, opt => opt.MapFrom(src => src.ListItems))
                    .ReverseMap();
            
            CreateMap<ListEntity, ListDto>()
                    // .ForMember(dest => dest.ListItems, opt => opt.MapFrom(src => src.ListItems))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                    .ReverseMap();

            CreateMap<ListItemEntity, ListItemInListDto>()
                    .ReverseMap();
                    

            CreateMap<ListEntity, ListCreateResultDto>()
                   .ForMember(dest => dest.ListItems, opt => opt.MapFrom(src => src.ListItems))
                   .ReverseMap();


        }
    }
}

