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
                    Failure = Error.NotFound("Currency.NotFound", ErrorMessages.Currency_NotFound)
                };

            return new BaseResult();
        }
    }
}