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
        /// <returns><c>double</c>: profit of period</returns>
        Task<BaseResult<double>> ProfitOfPeriod(int periodId);

        /// <summary>
        /// Get current user period 
        /// </summary>
        /// <param name="userId">User identificator</param>
        /// <returns><c>PeriodDto</c>: current user period if not expired
        /// <para><c>null</c>: otherwise</para></returns>
        Task<BaseResult<PeriodDto?>> CurrentPeriodByUserId(int userId);

        /// <summary>
        /// Create new period for user
        /// </summary>
        /// <param name="userId">User identificator</param>
        /// <returns><c>PeriodDto</c>: new user period</returns>
        Task<BaseResult<PeriodDto>> CreateNewPeriod(int userId);

        /// <summary>
        /// Delete period by identificator
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns><c>PeriodDto</c>: deleted period if success
        /// <para><c>null</c>: otherwise</para></returns>
        Task<BaseResult<PeriodDto?>> DeletePeriod(int periodId);
    }
}
