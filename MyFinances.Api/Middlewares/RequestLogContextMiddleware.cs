using Serilog.Context;

namespace MyFinances.Api.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="next">Next middleware</param>
    public class RequestLogContextMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public Task InvokeAsync(HttpContext context)
        {
            using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
            {
                return _next(context);
            }
        }
    }
}
