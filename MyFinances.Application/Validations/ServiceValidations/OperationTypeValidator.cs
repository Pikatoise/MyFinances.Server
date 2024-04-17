using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class OperationTypeValidator: IOperationTypeValidator
    {
        public BaseResult AddTypeAssociationValidator(OperationType? operationType, TypeAssociation? typeAssociation)
        {
            if (operationType == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("OperationType.NotFound", ErrorMessages.Currency_NotFound)
                };

            if (typeAssociation != null)
                return new BaseResult()
                {
                    Failure = Error.Conflict("TypeAssociation.AlreadyExist", ErrorMessages.TypeAssociation_AlreadyExist)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(OperationType? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("OperationType.NotFound", ErrorMessages.OperationType_NotFound)
                };

            return new BaseResult();
        }
    }
}
