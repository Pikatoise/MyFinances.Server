using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class PeriodValidator: IPeriodValidator
    {
        public BaseResult PeriodsPagingValidator(int currentPage, int step, string order, int periodsAmount)
        {
            bool isOutOfRange = currentPage * step > periodsAmount;
            bool isOrderNotCorrect = !(order.Equals("asc") || order.Equals("desc"));

            if (isOutOfRange)
                return new BaseResult()
                {
                    Failure = Error.Failure("Period.OutOfRange", ErrorMessages.Period_OutOfRange)
                };

            if (isOrderNotCorrect)
                return new BaseResult()
                {
                    Failure = Error.Failure("Period.IncorrectOrder", ErrorMessages.Period_IncorrectOrder)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(Period? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("Period.NotFound", ErrorMessages.Period_NotFound)
                };

            return new BaseResult();
        }
    }
}
