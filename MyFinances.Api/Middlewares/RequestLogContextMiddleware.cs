using Serilog.Context;

namespace MyFinances.Api.Middlewares
{
    /// <summary>
    /// Handle received request for logging
    /// </summary>
    /// <param name="next">Next middleware</param>
    public class RequestLogContextMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        /// <summary>
        /// Add identificator for request
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task InvokeAsync(HttpContext context)
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            {
                return _next(context);
            }
        }
    }
}
