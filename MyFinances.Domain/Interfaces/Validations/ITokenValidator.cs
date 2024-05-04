using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface ITokenValidator: IBaseValidator<UserToken>
    {
        /// <summary>
        /// Check is user exist, received token similar to origin and token not expired
        /// </summary>
        /// <param name="user">Token owner</param>
        /// <param name="receivedRefreshToken">Refresh token from dto</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateRefreshingToken(User? user, string receivedRefreshToken);
    }
}
