using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class FixerErrors
    {
        public static readonly Error FixerBadRequest = Error.Failure("Api.Fixer.BadRequest", ErrorMessages.Api_Fixer_BadRequest);
    }
}
