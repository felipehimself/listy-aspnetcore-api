﻿// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using Newtonsoft.Json;
// using System.Net;



// namespace Api.CrossCutting.Middlewares
// {
//     public class GlobalExeptionMiddleware
//     {
//         private readonly ILogger<GlobalExeptionMiddleware> _logger;

//         public GlobalExeptionMiddleware(ILogger<GlobalExeptionMiddleware> logger)
//         {
//             _logger = logger;
//         }



//         public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//         {
//             try
//             {
//                 await next(context);
//             }
//             catch (Exception e)
//             {
//                 _logger.LogError(e, message: e.Message);
//                 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                 context.Response.ContentType = "application/json";

//                 ProblemDetails problem = new()
//                 {
//                     Status = (int)HttpStatusCode.InternalServerError,
//                     Detail = "An error ocurred in the server",
//                 };

//                 await context.Response.WriteAsJsonAsync(problem);
//             }
//         }
//     }
// }