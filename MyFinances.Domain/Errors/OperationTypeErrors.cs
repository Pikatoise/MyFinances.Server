using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class OperationTypeErrors
    {
        public static readonly Error OperationTypeNotFound = Error.NotFound("OperationType.NotFound", ErrorMessages.OperationType_NotFound);
    }
}
