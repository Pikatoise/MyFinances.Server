using Microsoft.AspNetCore.Mvc;

namespace MyFinances.Api.Middlewares
{
    /// <summary>
    /// Middleware that convert application exception for user
    /// </summary>
    /// <param name="next">Next middleware</param>
    public class ExceptionHandlerMiddleware(/*ILogger logger,*/ RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        //private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "", ex.Message);

                var problemDetails = new ProblemDetails()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Server error"
                };

                httpContext.Response.ContentType = "application/json";

                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                await httpContext.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
