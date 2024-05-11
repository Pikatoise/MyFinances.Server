using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class TokenErrors
    {
        public static readonly Error TokenNotFound = Error.NotFound("UserToken.NotFound", ErrorMessages.UserToken_NotFound);
        public static readonly Error TokenIsInvalid = Error.Validation("UserToken.Invalid", ErrorMessages.UserToken_Invalid);
        public static readonly Error TokenExpired = Error.Failure("UserToken.Expired", ErrorMessages.UserToken_Expired);
        public static readonly Error TokenHasEmptyValues = Error.Validation("UserToken.EmptyValues", ErrorMessages.UserToken_Invalid);
    }
}
