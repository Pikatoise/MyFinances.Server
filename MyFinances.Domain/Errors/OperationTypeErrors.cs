using MyFinances.Domain.Resources;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Errors
{
    public static class OperationTypeErrors
    {
        public static readonly Error OperationTypeNotFound = Error.NotFound("OperationType.NotFound", ErrorMessages.OperationType_NotFound);

        public static readonly Error OperationTypeAlreadyExist = Error.Conflict("OperationType.AlreadyExist", ErrorMessages.OperationType_AlreadyExist);

        public static readonly Error TypeAssociationAlreadyExist = Error.Conflict("TypeAssociation.AlreadyExist", ErrorMessages.TypeAssociation_AlreadyExist);
    }
}
