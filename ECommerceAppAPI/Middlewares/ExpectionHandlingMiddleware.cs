using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ECommerceAppAPI.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExpectionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExpectionHandlingMiddleware> _logger;

    public ExpectionHandlingMiddleware(RequestDelegate next, ILogger<ExpectionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
        {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // Log the exception here (e.g., using a logging framework like Serilog, NLog, etc.)
            _logger.LogError($"{ex.GetType().ToString}:{ex.Message}");

            if (ex.InnerException is not null) {
                // Log the inner exception as well
                _logger.LogError($"{ex.InnerException.GetType().ToString}:{ex.InnerException.Message}");
            }

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            //Internal Server Error
            await httpContext.Response.WriteAsJsonAsync(new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message,
                Type = ex.GetType().ToString()
            });
        }

    }
}

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExpectionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExpectionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExpectionHandlingMiddleware>();
        }
    }

