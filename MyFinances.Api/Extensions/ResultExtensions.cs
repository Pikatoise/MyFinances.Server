using MyFinances.Domain.Enum;
using MyFinances.Domain.Result;

namespace MyFinances.Api.Extensions
{
    /// <summary>
    /// Extensions for Result entity
    /// </summary>
    public static class ResultExtensions
    {
        /// <summary>
        /// Convert result to HTTP response
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IResult ToProblemDetails(this BaseResult result)
        {
            if (result.IsSuccess || result.Failure == null)
                throw new InvalidOperationException();

            return Results.Problem
                (
                    statusCode: GetStatusCode(result.Failure.Type),
                    title: GetTitle(result.Failure.Type),
                    extensions: new Dictionary<string, object?>
                    {
                        { "errors", result.Failure }
                    }
                );
        }

        static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError
            };

        static string GetTitle(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Failure => "Server Failure",
                ErrorType.Validation => "Incorrect data",
                ErrorType.NotFound => "No data found",
                ErrorType.Conflict => "Caused conflict",
                _ => "Unexpected failure"
            };
    }
}
