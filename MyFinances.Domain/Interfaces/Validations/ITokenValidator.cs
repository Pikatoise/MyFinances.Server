using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface ITokenValidator: IBaseValidator<UserToken>
    {
        /// <summary>
        /// Check is received token similar to origin and token not expired
        /// </summary>
        /// <param name="user">Token owner</param>
        /// <param name="receivedRefreshToken">Refresh token from dto</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateRefreshTokenAuthentic(User? user, string receivedRefreshToken);

        /// <summary>
        /// Check is token exists and not similar
        /// </summary>
        /// <param name="refreshToken">Received refresh token</param>
        /// <param name="accessToken">Received access token</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateTokensExists(string? refreshToken, string? accessToken);
    }
}
