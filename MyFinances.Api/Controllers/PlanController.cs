using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.DTO.Plan;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PlanController(IPlanService planService): ControllerBase
    {
        private readonly IPlanService _planService = planService;

        [HttpGet("{userId}")]
        public async Task<IResult> GetPlansByUserId(int userId)
        {
            var response = await _planService.GetPlansByUserId(userId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpDelete("remove/{planId}")]
        public async Task<IResult> DeletePlan(int planId)
        {
            var response = await _planService.DeletePlan(planId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPut("changeStatus/{planId}/{status}")]
        public async Task<IResult> ChangePlanStatus(int planId, int status)
        {
            var response = await _planService.ChangePlanStatus(planId, status);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPost("add")]
        public async Task<IResult> CreatePlan([FromBody] CreatePlanDto dto)
        {
            var response = await _planService.CreatePlan(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPut("change")]
        public async Task<IResult> UpdatePlan([FromBody] UpdatePlanDto dto)
        {
            var response = await _planService.UpdatePlan(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }
    }
}
