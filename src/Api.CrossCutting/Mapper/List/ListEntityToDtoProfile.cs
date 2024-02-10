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


                        // Dto to Entity
                        CreateMap<ListCreateDto, ListEntity>()
                                .ForMember(dest => dest.ListItems, opt => opt.MapFrom(src => src.ListItems.Select(x => new ListItemEntity { Content = x })));

                        // Entity to dto
                        CreateMap<ListEntity, ListCreateResultDto>();

                        // Required for mapping from ListEntity to ListCreateResultDto
                        CreateMap<ListItemEntity, ListItemCreateDto>()
                                 .ReverseMap();


                        CreateMap<ListUpdateDto, ListEntity>();
                        CreateMap<ListEntity, ListUpdateResultDto>();

                        CreateMap<ListItemEntity, ListItemUpdateDto>()
                                .ReverseMap();


                        // Entity to dto
                        CreateMap<ListEntity, ListDto>()
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.Name))
                                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));

                        // Required for mapping from ListEntity to ListDto
                        CreateMap<ListItemEntity, ListItemInListDto>()
                                .ReverseMap();


                }
        }
}

