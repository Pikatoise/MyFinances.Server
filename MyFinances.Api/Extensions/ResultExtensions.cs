using MyFinances.Domain.Result;

namespace MyFinances.Api.Extensions
{
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
            if (result.IsSuccess)
                throw new InvalidOperationException();

            return Results.Problem(
                statusCode: result.ErrorCode,
                title: "Bad request",
                extensions: new Dictionary<string, object?>
                {
                    { "errors", result.ErrorMessage }
                });
        }
    }
}
