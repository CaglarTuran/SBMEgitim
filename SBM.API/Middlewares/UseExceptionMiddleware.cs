using Microsoft.AspNetCore.Diagnostics;
using SBM.Core.DTOs;
using SBM.Services.Exceptions;
using System.Text.Json;

namespace SBM.API.Middlewares
{
    public static class UseExceptionMiddleware
    {
        public static void UseException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
               {
                   context.Response.ContentType = "application/json";

                   var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                   var statusCode = exceptionFeature.Error switch

                   {
                       ProductNotFoundException => 400,
                       _ => 500
                   };

                   context.Response.StatusCode = statusCode;
                   var response = ResponseDto<NoContent>.Fail(statusCode, exceptionFeature.Error.Message);

                   await context.Response.WriteAsync(JsonSerializer.Serialize(response));
               });
            });
        }
    }
}