using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Application.Services;

namespace MyFinances.Api.Controllers
{
    /// <summary>
    /// Temporary controller 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class TempController(ILogger<TempController> logger, FixerService fixerService): ControllerBase
    {
        private readonly ILogger<TempController> _logger = logger;
        private readonly FixerService _fixerService = fixerService;


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
        public async Task<IResult> Get()
        {
            _logger.LogInformation($"Get request --- {DateTime.Now.ToShortTimeString()}");

            var result = await _fixerService.GetCurrencies();

            return Results.Ok(result);
        }
    }
}
