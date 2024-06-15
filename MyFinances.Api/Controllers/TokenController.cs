using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.DTO;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController(ITokenService tokenService): ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost]
        public async Task<IResult> RefreshToken([FromBody] TokenDto tokenDto)
        {
            var response = await _tokenService.RefreshToken(tokenDto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        [HttpGet]
        [Authorize]
        public async Task<IResult> ValidateAccessToken()
        {
            return Results.Ok();
        }
    }
}
