using MyFinances.Domain.Entity;
using MyFinances.Domain.Errors;
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
                    Failure = TokenErrors.TokenNotFound
                };

            return new BaseResult();
        }

        public BaseResult ValidateRefreshTokenAuthentic(User? user, string receivedRefreshToken)
        {
            if (user == null)
                return new BaseResult()
                {
                    Failure = TokenErrors.TokenNotFound
                };

            if (!user.UserToken.RefreshToken.Equals(receivedRefreshToken))
                return new BaseResult()
                {
                    Failure = TokenErrors.TokenIsInvalid
                };

            if (user.UserToken.RefreshTokenExpiryTime <= DateTime.UtcNow)
                return new BaseResult()
                {
                    Failure = TokenErrors.TokenExpired
                };

            return new BaseResult();
        }

        public BaseResult ValidateTokensExists(string? refreshToken, string? accessToken)
        {
            if (refreshToken == null || accessToken == null)
                return new BaseResult()
                {
                    Failure = TokenErrors.TokenIsInvalid
                };

            if (string.IsNullOrWhiteSpace(refreshToken) || string.IsNullOrWhiteSpace(accessToken))
                return new BaseResult()
                {
                    Failure = TokenErrors.TokenHasEmptyValues
                };

            return new BaseResult();
        }
    }
}
