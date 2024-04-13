using Microsoft.AspNetCore.Mvc;

namespace MyFinances.Api.Middlewares
{
    /// <summary>
    /// Global exception handler
    /// </summary>
    /// <param name="logger">Logger from DI</param>
    /// <param name="next">Next middleware</param>
    public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger = logger;

        /// <summary>
        /// Try to execute next middleware and if it throw exception, log it and return response
        /// </summary>
        /// <param name="httpContext">Http data of request</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);

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
