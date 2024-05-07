using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    /// <summary>
    /// Currency controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CurrencyController(ICurrencyService currencyService): ControllerBase
    {
        private readonly ICurrencyService _currencyService = currencyService;

        [HttpGet("{currencyName}")]
        public async Task<IResult> GetCurrencyValue(string currencyName)
        {
            var response = await _currencyService.GetCurrencyValue(currencyName);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }
    }
}
