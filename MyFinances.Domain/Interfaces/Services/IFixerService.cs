using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service responsible to access external currency API
    /// </summary>
    public interface IFixerService
    {
        /// <summary>
        /// Get all supported currencies from API
        /// </summary>
        /// <returns><c>Collection of Currency</c>: fresh currencies from api</returns>
        Task<CollectionResult<Currency>> GetCurrencies();
    }
}
