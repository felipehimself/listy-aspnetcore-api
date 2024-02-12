

using Api.Service.Services.Authentication;
using Microsoft.AspNetCore.Http;

namespace Api.CrossCutting.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                AttachUserToContext(context, token);
            }

            await _next(context);
        }

        private static void AttachUserToContext(HttpContext context, string token)
        {

            var user = AuthenticationService.ValidateAndDecodeToken(token);

            if (user != null)
            {


                context.Items["UserId"] = user.UserId;
                context.Items["Role"] = user.Role;
            }
            else
            {
                Console.Write("aaaa");
            };


        }
    }
}