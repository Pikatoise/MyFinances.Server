using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class CurrencyErrors
    {
        public static readonly Error CurrencyNotFound = Error.NotFound("Currency.NotFound", ErrorMessages.Currency_NotFound);

        public static readonly Error CurrencyExpired = Error.Failure("Currency.Expired", ErrorMessages.Currency_Expired);

        public static readonly Error CurrencyNotSupported = Error.Conflict("Currency.NotSupported", ErrorMessages.Currency_NotSupported);
    }
}
