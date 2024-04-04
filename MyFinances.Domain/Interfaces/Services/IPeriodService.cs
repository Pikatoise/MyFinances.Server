using MyFinances.Domain.DTO.Period;
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
        /// <returns><c>double</c>: Profit of period</returns>
        Task<BaseResult<double>> ProfitOfPeriod(int periodId);

        /// <summary>
        /// Get current user period 
        /// </summary>
        /// <param name="userId">User identificator</param>
        /// <returns><c>PeriodDto</c>: Current user period if not expired, null otherwise</returns>
        Task<BaseResult<PeriodDto?>> CurrentPeriodByUserId(int userId);


        /// <summary>
        /// Generate new period for user
        /// </summary>
        /// <param name="userId">User identificator</param>
        /// <returns><c>PeriodDto</c>: New user period</returns>
        Task<BaseResult<PeriodDto>> GenerateNewPeriod(int userId);
    }
}
