using MyFinances.Domain.DTO;
using MyFinances.Domain.DTO.User;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service for user authentication
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="dto">Data for registration</param>
        /// <returns><c>UserDto</c>: data of registred user</returns>
        Task<BaseResult<UserDto>> Register(RegisterUserDto dto);

        /// <summary>
        /// Authorization
        /// </summary>
        /// <param name="dto">Data for authorization</param>
        /// <returns><c>TokenDto</c>: tokens for auth</returns>
        Task<BaseResult<TokenDto>> Login(LoginUserDto dto);
    }
}
