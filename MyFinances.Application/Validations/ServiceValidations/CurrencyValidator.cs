using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class CurrencyValidator: ICurrencyValidator
    {
        public BaseResult ValidateOnNull(Currency? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.Validation("Currency.NotExist", ErrorMessages.Currency_NotExist)
                };

            return new BaseResult();
        }
    }
}