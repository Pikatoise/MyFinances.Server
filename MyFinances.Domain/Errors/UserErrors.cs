using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class UserErrors
    {
        public static readonly Error UserNotFound = Error.NotFound("User.NotFound", ErrorMessages.User_NotFound);
    }
}
