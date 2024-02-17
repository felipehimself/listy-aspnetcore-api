using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
using Api.Service.Services.Admin;
using Api.Service.Services.Authentication;
using Api.Service.Services.Category;
using Api.Service.Services.Comment;
using Api.Service.Services.List;
using Api.Service.Services.Login;
using Api.Service.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.Configs
{
    public static class ConfigServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IListService, ListService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAdminService, AdminService>();

            return services;

        }

    }
}