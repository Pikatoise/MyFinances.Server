using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    /// <summary>
    /// Temporary controller 
    /// </summary>
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class TempController(ICurrencyService currencyService): ControllerBase
    {
        private readonly ICurrencyService _currencyService = currencyService;

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
        [HttpGet("{currencyName}")]
        public async Task<IResult> Get(string currencyName)
        {
            var result = await _currencyService.GetCurrencyValue(currencyName);

            if (!result.IsSuccess)
                return result.ToProblemDetails();

            return Results.Ok(result);
        }
    }
}
