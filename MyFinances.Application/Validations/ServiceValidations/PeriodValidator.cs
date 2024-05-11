using MyFinances.Domain.Entity;
using MyFinances.Domain.Errors;
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
                    Failure = PeriodErrors.PeriodOutOfRange
                };

            if (isOrderNotCorrect)
                return new BaseResult()
                {
                    Failure = PeriodErrors.PeriodIncorrectOrder
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(Period? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = PeriodErrors.PeriodNotFound
                };

            return new BaseResult();
        }
    }
}
