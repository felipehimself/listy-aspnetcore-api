using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Api.Service.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Configs
{
    public static class ConfigServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection service)
        {


            service.AddScoped<IUserService, UserService>();



            return service;

        }

    }
}