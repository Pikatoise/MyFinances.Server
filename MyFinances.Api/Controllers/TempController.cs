using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="message">Test message (can be empty)</param>
        /// <remarks>
        /// Request for test get:
        /// 
        ///     GET(message)
        ///     
        /// </remarks>
        /// <response code="200">Ok - request successfuly worked out</response>
        /// <response code="400">Fail - server can't process request</response>
        [HttpGet("{message}")]
        public ActionResult<string> Get(string message = "NONE")
        {
            _logger.LogDebug($"Get request --- {DateTime.Now.ToShortTimeString()}");

            return Ok($"Success\nMessage: {message}");
        }
    }
}
