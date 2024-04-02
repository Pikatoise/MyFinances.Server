using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service responsible for period controle
    /// </summary>
    public interface IPeriodService
    {
        /// <summary>
        /// Get profit of all operations by period
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns>Profit: double</returns>
        Task<BaseResult<double>> ProfitOfPeriod(int periodId);
    }
}
