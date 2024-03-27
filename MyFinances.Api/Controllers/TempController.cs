using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace MyFinances.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]
    public class TempController: ControllerBase
    {
        private readonly ILogger<TempController> _logger;

        public TempController(ILogger<TempController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            _logger.LogDebug($"Get request --- {DateTime.Now.ToShortTimeString()}");

            return Ok("Success");
        }
    }
}
