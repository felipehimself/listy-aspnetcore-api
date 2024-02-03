
using Api.Data.Repositories;
using Api.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Configs
{
    public static class ConfigDependencyInjection
    {

        public static IServiceCollection AddApiDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            return services;


        }


    }
}