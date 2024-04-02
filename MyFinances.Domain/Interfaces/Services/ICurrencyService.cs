﻿using MyFinances.Domain.DTO.Currency;
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
        /// <returns>
        /// CurrencyDto:
        /// {
        ///     "Value": double converted to string
        /// }
        /// </returns>
        Task<BaseResult<CurrencyDto>> GetCurrencyValue(string currencyName);

        /// <summary>
        /// Update server stored value of available currency
        /// </summary>
        /// <returns>A boolean value that indicates whether the update is successful</returns>
        Task<BaseResult<bool>> UpdateCurrency();
    }
}
