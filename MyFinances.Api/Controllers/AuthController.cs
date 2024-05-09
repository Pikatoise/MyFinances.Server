using Microsoft.AspNetCore.Mvc;
using MyFinances.Api.Extensions;
using MyFinances.Domain.DTO.User;
using MyFinances.Domain.Interfaces.Services;

namespace MyFinances.Api.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService): ControllerBase
    {
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// User registration
        /// </summary>
        /// <param name="dto">Data for registration</param>
        /// <remarks>
        /// Request for register user:
        /// 
        ///     POST
        ///     {
        ///         "Login": "UserLogin"
        ///         "Password": "qwerty"
        ///         "PasswordConfirm": "qwerty"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Succesfull registration</response>
        /// <response code="400">Some error</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IResult> Register([FromBody] RegisterUserDto dto)
        {
            var response = await _authService.Register(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }

        /// <summary>
        /// User log in
        /// </summary>
        /// <param name="dto">Data for auth</param>
        /// <remarks>
        /// Request for auth user:
        /// 
        ///     POST
        ///     {
        ///         "Login": "UserLogin"
        ///         "Password": "qwerty"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Succesfull auth</response>
        /// <response code="400">Some error</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IResult> Login([FromBody] LoginUserDto dto)
        {
            var response = await _authService.Login(dto);

            return response.IsSuccess ? Results.Ok(response) : response.ToProblemDetails();
        }
    }
}
