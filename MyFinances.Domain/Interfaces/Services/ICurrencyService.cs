using MyFinances.Domain.DTO.Currency;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Services responsible for currency 
    /// </summary>
    public interface ICurrencyService
    {
        /// <summary>
        /// Get value of requested currency
        /// </summary>
        /// <param name="currencyName">Abbreviation of currency</param>
        /// <returns><c>CurrencyDto</c>: value of requested currency</returns>
        Task<BaseResult<CurrencyDto>> GetCurrencyValue(string currencyName);

        /// <summary>
        /// Update server stored value of available currency
        /// </summary>
        /// <returns><c>BaseResult</c>: empty BaseResult, if update was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        Task<BaseResult> UpdateCurrencies();
    }
}
