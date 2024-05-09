using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class TokenValidator: ITokenValidator
    {
        public BaseResult ValidateOnNull(UserToken? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("UserToken.NotFound", ErrorMessages.UserToken_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidateRefreshTokenAuthentic(User? user, string receivedRefreshToken)
        {
            if (user == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound)
                };

            if (!user.UserToken.RefreshToken.Equals(receivedRefreshToken))
                return new BaseResult()
                {
                    Failure = Error.Failure("UserToken.Invalid", ErrorMessages.UserToken_Invalid)
                };

            if (user.UserToken.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return new BaseResult()
                {
                    Failure = Error.Failure("UserToken.Expired", ErrorMessages.UserToken_Expired)
                };

            return new BaseResult();
        }

        public BaseResult ValidateTokensExists(string? refreshToken, string? accessToken)
        {
            if (refreshToken == null || accessToken == null)
                return new BaseResult()
                {
                    Failure = Error.Validation("UserToken.Invalid", ErrorMessages.UserToken_Invalid)
                };

            if (string.IsNullOrWhiteSpace(refreshToken) || string.IsNullOrWhiteSpace(accessToken))
                return new BaseResult()
                {
                    Failure = Error.Validation("UserToken.EmptyValues", ErrorMessages.UserToken_Invalid)
                };

            return new BaseResult();
        }
    }
}
