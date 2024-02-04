using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


                       });

            return configMapper.CreateMapper();

        }


    }
}