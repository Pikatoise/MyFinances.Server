using MyFinances.Domain.DTO;
using MyFinances.Domain.Result;
using System.Security.Claims;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service responsible for JWT tokens generation and validation
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate new access token
        /// </summary>
        /// <param name="claims">User claims</param>
        /// <returns><c>string</c>: access token</returns>
        string GenerateAccessToken(IEnumerable<Claim> claims);

        /// <summary>
        /// Generate new refresh token
        /// </summary>
        /// <returns><c>string</c>: refresh token</returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Extract claims from expired token
        /// </summary>
        /// <param name="token">Expired token</param>
        /// <returns><c>ClaimsPrincipal</c>: extracted claims</returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);

        /// <summary>
        /// Update token
        /// </summary>
        /// <param name="dto">Data for token updating</param>
        /// <returns><c>TokenDto</c>: data of fresh token</returns>
        Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);
    }
}
