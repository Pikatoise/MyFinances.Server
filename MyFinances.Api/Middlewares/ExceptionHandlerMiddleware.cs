using MyFinances.Api.Extensions;
using MyFinances.Domain.Result;

namespace MyFinances.Api.Middlewares
{
    /// <summary>
    /// Middleware that convert application exception for user
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="next"></param>
    public class ExceptionHandlerMiddleware(/*ILogger logger,*/ RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        //private readonly ILogger _logger = logger;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            //_logger.Error(ex, ex.Message);

            var response = ex switch
            {
                _ => new BaseResult()
                {
                    Failure = Error.Failure("", "")
                }.ToProblemDetails()
            };

            httpContext.Response.ContentType = "application/json";

            //httpContext.Response.StatusCode = response;

            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
