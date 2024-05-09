using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PeriodController(IPeriodService periodService): ControllerBase
    {
        private readonly IPeriodService _periodService = periodService;

        [HttpGet("profitOf/{periodId}")]
        public async Task<IResult> ProfitOfPeriod(int periodId)
        {
            var response = await _periodService.ProfitOfPeriod(periodId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpGet("{userId}")]
        public async Task<IResult> CurrentPeriodByUserId(int userId)
        {
            var response = await _periodService.CurrentPeriodByUserId(userId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpGet("{userId}/{year}/{month}")]
        public async Task<IResult> GetByYearAndMonth(int userId, int year, int month)
        {
            var response = await _periodService.GetByYearAndMonth(userId, year, month);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpGet("{userId}/{currentPage}/{step}/{order}")]
        public async Task<IResult> PeriodsPaging(int userId, int currentPage, int step, string order)
        {
            var response = await _periodService.PeriodsPaging(userId, currentPage, step, order);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPost("add/{userId}")]
        public async Task<IResult> CreateNewPeriod(int userId)
        {
            var response = await _periodService.CreateNewPeriod(userId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpDelete("remove/{periodId}")]
        public async Task<IResult> DeletePeriod(int periodId)
        {
            var response = await _periodService.DeletePeriod(periodId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }
    }
}
