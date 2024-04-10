using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.Result;

namespace MyFinances.Api.Controllers
{
    /// <summary>
    /// Temporary controller 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class TempController(ILogger<TempController> logger): ControllerBase
    {
        private readonly ILogger<TempController> _logger = logger;

        /// <summary>
        /// Empty get request
        /// </summary>
        /// <remarks>
        /// Request for test get:
        /// 
        ///     GET()
        ///     
        /// </remarks>
        /// <response code="200">Ok - request successfuly worked out</response>
        /// <response code="400">Fail - server can't process request</response>
        [HttpGet()]
        public IResult Get()
        {
            _logger.LogDebug($"Get request --- {DateTime.Now.ToShortTimeString()}");

            var result = new BaseResult<string>()
            {
                Failure = Error.Conflict("User.Conflit", "Some conflict")
            };

            if (result.IsSuccess)
                return Results.Ok("Successful request");
            else
                return result.ToProblemDetails();
        }
    }
}
