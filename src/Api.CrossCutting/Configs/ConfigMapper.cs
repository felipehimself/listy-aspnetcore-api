using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.Mapper.Category;
using Api.CrossCutting.Mapper.List;
using Api.CrossCutting.Mapper.User;
using AutoMapper;

namespace Api.CrossCutting.Configs
{
    public static class ConfigMapper
    {

        public static IMapper ConfigApiMapper()
        {



            var configMapper = new AutoMapper.MapperConfiguration(config =>
                       {
                           config.AddProfile(new UserEntityToDtoProfile());
                           config.AddProfile(new ListEntityToDtoProfile());
                           config.AddProfile(new CategoryEntityToDtoProfile());

                       });

            return configMapper.CreateMapper();

        }


    }
}