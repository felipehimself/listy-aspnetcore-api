using Api.CrossCutting.Configs;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Api.CrossCutting.Mapper.User;

namespace Application;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApiConnection();
        builder.Services.AddApiDependencyInjection();
        builder.Services.AddApiServices();

        // Default for model state invalid
        builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

        // Default lowercase for endpoints
        builder.Services.AddRouting(options => options.LowercaseUrls = true);

        // Config Automapper
        builder.Services.AddSingleton(ConfigMapper.ConfigApiMapper());




        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
