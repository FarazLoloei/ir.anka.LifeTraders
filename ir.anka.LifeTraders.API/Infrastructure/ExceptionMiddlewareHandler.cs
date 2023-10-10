using ir.anka.LifeTraders.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ir.anka.LifeTraders.WebAPI.Infrastructure;

public class ExceptionMiddlewareHandler
{
    public static Action<IApplicationBuilder> HandleExceptions()
    {
        return a => a.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            string result;
            if (exception is DomainException)
            {
                result = JsonSerializer.Serialize(new { message = exception.Message });
                Console.WriteLine(exception.Message);
            }
            else
            {
                result = JsonSerializer.Serialize(new { message = $"Internal Server Error : {exception}" });
            }
            await context.Response.WriteAsync(result);
        });
    }
}