using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class OperationValidator: IOperationValidator
    {
        public BaseResult CreateValidator(Period operationPeriod, OperationType operationType)
        {
            if (operationPeriod == null)
                return new BaseResult()
                {
                    Failure = Error.Validation("OperationPeriod.NotFound", ErrorMessages.OperationPeriod_NotFound)
                };

            if (operationType == null)
                return new BaseResult()
                {
                    Failure = Error.Validation("OperationType.NotFound", ErrorMessages.OperationType_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult UpdateValidator(Operation operation, OperationType operationType)
        {
            if (operation == null)
                return new BaseResult()
                {
                    Failure = Error.Validation("Operation.NotFound", ErrorMessages.Operation_NotFound)
                };

            if (operationType == null)
                return new BaseResult()
                {
                    Failure = Error.Validation("OperationType.NotFound", ErrorMessages.OperationType_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(Operation? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.Validation("Operation.NotFound", ErrorMessages.Operation_NotFound)
                };

            return new BaseResult();
        }
    }
}
