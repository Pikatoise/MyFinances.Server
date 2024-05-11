using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class OperationErrors
    {
        public static readonly Error OperationNotFound = Error.NotFound("Operation.NotFound", ErrorMessages.Operation_NotFound);
    }
}
