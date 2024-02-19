using Api.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;



namespace Api.CrossCutting.Middlewares
{
    public class GlobalExeptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExeptionMiddleware> _logger;


        public GlobalExeptionMiddleware(ILogger<GlobalExeptionMiddleware> logger)
        {
            _logger = logger;

        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }

            catch (CustomException e)
            {
                Console.WriteLine("Custom Exception: " + e.Message);
                _logger.LogError(e, message: e.Message);

                context.Response.StatusCode = (int)e.StatusCode;
                context.Response.ContentType = "application/json";

                var errorResponse = new { message = e.Message };
                var jsonResponse = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(jsonResponse);

            }

            catch (Exception e)
            {
                _logger.LogError(e, message: e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                ProblemDetails problem = new()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Detail = "Um erro ocorreu no servidor",
                };

                await context.Response.WriteAsJsonAsync(problem);
            }
        }
    }
}