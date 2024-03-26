using Microsoft.AspNetCore.Mvc;

namespace MyFinances.Api.Controllers
{
    [ApiController]
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
            return Ok("Success");
        }
    }
}
