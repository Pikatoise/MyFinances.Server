using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.DTO.Role;
using MyFinances.Domain.DTO.UserRole;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = $"{nameof(Roles.Admin)}")]
    public class RoleController(IRoleService roleService): ControllerBase
    {
        private readonly IRoleService _roleService = roleService;

        [HttpPost("add/{roleName}")]
        public async Task<IResult> CreateRole(string roleName)
        {
            var response = await _roleService.CreateRoleAsync(roleName);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpDelete("remove/{roleId}")]
        public async Task<IResult> DeleteRole(int roleId)
        {
            var response = await _roleService.DeleteRoleAsync(roleId);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPut("change")]
        public async Task<IResult> UpdateRole([FromBody] RoleDto dto)
        {
            var response = await _roleService.UpdateRoleAsync(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpPut("set")]
        public async Task<IResult> SetRoleToUserAsync([FromBody] AddUserRoleDto dto)
        {
            var response = await _roleService.SetRoleToUserAsync(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpDelete("remove/user")]
        public async Task<IResult> RemoveUserRole([FromBody] RemoveUserRoleDto dto)
        {
            var response = await _roleService.RemoveUserRole(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }
    }
}
