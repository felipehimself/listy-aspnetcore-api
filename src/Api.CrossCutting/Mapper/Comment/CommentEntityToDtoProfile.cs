using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Comment;
using Api.Domain.Entities.Comment;
using AutoMapper;

namespace Api.CrossCutting.Mapper.Comment
{
    public class CommentEntityToDtoProfile : Profile
    {

        public CommentEntityToDtoProfile()
        {

            CreateMap<CommentCreateDto, CommentEntity>();
            CreateMap<CommentEntity, CommentCreateResultDto>();



        }


    }
}