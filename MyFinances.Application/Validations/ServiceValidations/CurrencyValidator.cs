using MyFinances.Application.Resources;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class CurrencyValidator: ICurrencyValidator
    {
        public BaseResult ValidateOnExpired(Currency? currency)
        {
            if (currency == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("Currency.NotFound", ErrorMessages.Currency_NotFound)
                };

            if (currency.UpdatedAt != null)
            {
                if (currency.UpdatedAt.Value.AddHours(1) < DateTime.Now)
                    return new BaseResult()
                    {
                        Failure = Error.Failure("Currency.Expired", ErrorMessages.Currency_Expired)
                    };
            }
            else if (currency.CreatedAt.AddHours(1) < DateTime.Now)
                return new BaseResult()
                {
                    Failure = Error.Failure("Currency.Expired", ErrorMessages.Currency_Expired)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(Currency? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = Error.NotFound("Currency.NotFound", ErrorMessages.Currency_NotFound)
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnSupport(string currencyName)
        {
            bool isSupported = false;

            if (nameof(Currencies.USD).Equals(currencyName))
                isSupported = true;

            if (nameof(Currencies.EUR).Equals(currencyName))
                isSupported = true;

            if (!isSupported)
                return new BaseResult()
                {
                    Failure = Error.NotFound("Currency.NotFound", ErrorMessages.Currency_NotFound)
                };

            return new BaseResult();
        }
    }
}