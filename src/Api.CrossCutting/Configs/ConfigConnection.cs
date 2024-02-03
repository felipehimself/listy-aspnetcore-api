using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Configs
{
    public static class ConfigConnection
    {
        public static IServiceCollection AddApiConnection(this IServiceCollection services)
        {

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
            var mySqlVersion = Environment.GetEnvironmentVariable("MYSQL_VERSION");

            services.AddDbContext<MyContext>(options => options.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse(mySqlVersion)));


            return services;
        }
    }
}