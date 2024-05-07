using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OperationTypeController(IOperationTypeService operationTypeService): ControllerBase
    {
        private readonly IOperationTypeService _operationTypeService = operationTypeService;

        [Authorize(Roles = $"{nameof(Roles.Admin)}")]
        [HttpPost("associations/add")]
        public async Task<IResult> AddTypeAssociation(int typeId, string association)
        {
            var response = await _operationTypeService.AddTypeAssociation(typeId, association);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpGet]
        public async Task<IResult> GetAllTypes()
        {
            var response = await _operationTypeService.GetAllTypes();

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpGet("{association}")]
        public async Task<IResult> GetTypesByAssociation(string association)
        {
            var response = await _operationTypeService.GetTypesByAssociation(association);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }
    }
}
