using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    /// <summary>
    /// Collection of validators for currency service
    /// </summary>
    public interface ICurrencyValidator: IBaseValidator<Currency>
    {
        /// <summary>
        /// Check is currency value is expired
        /// </summary>
        /// <param name="currency">Currency for validation</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnExpired(Currency currency);

        /// <summary>
        /// Check is currency supported
        /// </summary>
        /// <param name="currencyName">Currency for validation</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult ValidateOnSupport(string currencyName);
    }
}
