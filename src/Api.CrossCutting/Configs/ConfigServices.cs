using System.Threading.Tasks;
using Api.Domain.Interfaces.Services;
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
        public static IServiceCollection AddApiServices(this IServiceCollection service)
        {


            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IListService, ListService>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ILoginService, LoginService>();
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<ICommentService, CommentService>();

            return service;

        }

    }
}