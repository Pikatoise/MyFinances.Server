using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    /// <summary>
    /// Currency controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OperationController(IOperationService operationService): ControllerBase
    {
        private readonly IOperationService _operationService = operationService;

        [HttpGet("diagram/GroupByTypeAndSum/{periodId}")]
        public async Task<IResult> GroupByTypeAndSum(int periodId)
        {
            var response = await _operationService.GroupByTypeAndSum(periodId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpGet("{periodId}")]
        public async Task<IResult> GetOperationsByPeriod(int periodId, int? typeId, bool? isProfit)
        {
            var response = await _operationService.GetOperationsByPeriod(periodId, typeId, isProfit);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpDelete("remove/{operationId}")]
        public async Task<IResult> DeleteOperationById(int operationId)
        {
            var response = await _operationService.DeleteOperationById(operationId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPost("add")]
        public async Task<IResult> CreateOperation([FromBody] CreateOperationDto dto)
        {
            var response = await _operationService.CreateOperation(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPut("change")]
        public async Task<IResult> UpdateOperation([FromBody] UpdateOperationDto dto)
        {
            var response = await _operationService.UpdateOperation(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }
    }
}
