using MyFinances.Domain.Entity;
using MyFinances.Domain.Errors;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class OperationTypeValidator: IOperationTypeValidator
    {
        public BaseResult AddOperationTypeValidator(OperationType? operationType)
        {
            if (operationType != null)
                return new BaseResult()
                {
                    Failure = OperationTypeErrors.OperationTypeAlreadyExist
                };

            return new BaseResult();
        }

        public BaseResult AddTypeAssociationValidator(OperationType? operationType, TypeAssociation? typeAssociation)
        {
            if (operationType == null)
                return new BaseResult()
                {
                    Failure = OperationTypeErrors.OperationTypeNotFound
                };

            if (typeAssociation != null)
                return new BaseResult()
                {
                    Failure = OperationTypeErrors.TypeAssociationAlreadyExist
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(OperationType? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = OperationTypeErrors.OperationTypeNotFound
                };

            return new BaseResult();
        }
    }
}
