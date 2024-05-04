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

        public BaseResult ValidateRefreshingToken(User? user, string receivedRefreshToken)
        {
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
    }
}
