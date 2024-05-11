using MyFinances.Domain.Entity;
using MyFinances.Domain.Errors;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class OperationValidator: IOperationValidator
    {
        public BaseResult CreateValidator(Period? operationPeriod, OperationType? operationType)
        {
            if (operationPeriod == null)
                return new BaseResult()
                {
                    Failure = PeriodErrors.PeriodNotFound
                };

            if (operationType == null)
                return new BaseResult()
                {
                    Failure = OperationTypeErrors.OperationTypeNotFound
                };

            return new BaseResult();
        }

        public BaseResult UpdateValidator(Operation? operation, OperationType? operationType)
        {
            if (operation == null)
                return new BaseResult()
                {
                    Failure = OperationErrors.OperationNotFound
                };

            if (operationType == null)
                return new BaseResult()
                {
                    Failure = OperationTypeErrors.OperationTypeNotFound
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(Operation? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = OperationErrors.OperationNotFound
                };

            return new BaseResult();
        }
    }
}
