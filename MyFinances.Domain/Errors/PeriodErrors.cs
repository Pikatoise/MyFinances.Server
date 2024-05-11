using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class PeriodErrors
    {
        public static readonly Error PeriodNotFound = Error.NotFound("Period.NotFound", ErrorMessages.Period_NotFound);

        public static readonly Error PeriodOutOfRange = Error.Failure("Period.OutOfRange", ErrorMessages.Period_OutOfRange);

        public static readonly Error PeriodIncorrectOrder = Error.Failure("Period.IncorrectOrder", ErrorMessages.Period_IncorrectOrder);
    }
}
