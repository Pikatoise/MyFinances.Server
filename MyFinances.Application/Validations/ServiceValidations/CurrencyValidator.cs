using MyFinances.Domain.Entity;
using MyFinances.Domain.Enum;
using MyFinances.Domain.Errors;
using MyFinances.Domain.Interfaces.Validations;
using MyFinances.Domain.Result;

namespace MyFinances.Application.Validations.ServiceValidations
{
    public class CurrencyValidator: ICurrencyValidator
    {
        public BaseResult ValidateOnExpired(Currency? currency)
        {
            int updateTimeHours = 5;

            if (currency == null)
                return new BaseResult()
                {
                    Failure = CurrencyErrors.CurrencyNotFound
                };

            if (currency.UpdatedAt != null)
            {
                if (currency.UpdatedAt.Value.AddHours(updateTimeHours) < DateTime.Now)
                    return new BaseResult()
                    {
                        Failure = CurrencyErrors.CurrencyExpired
                    };
            }
            else if (currency.CreatedAt.AddHours(updateTimeHours) < DateTime.Now)
                return new BaseResult()
                {
                    Failure = CurrencyErrors.CurrencyExpired
                };

            return new BaseResult();
        }

        public BaseResult ValidateOnNull(Currency? model)
        {
            if (model == null)
                return new BaseResult()
                {
                    Failure = CurrencyErrors.CurrencyNotFound
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
                    Failure = CurrencyErrors.CurrencyNotSupported
                };

            return new BaseResult();
        }
    }
}