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
        Task<BaseResult<PeriodDto>> CurrentPeriodByUserId(int userId);

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
        Task<BaseResult<PeriodDto>> DeletePeriod(int periodId);

        /// <summary>
        /// Get specific period by year and month
        /// </summary>
        /// <param name="year">Year of requsted period</param>
        /// <param name="month">Month of requsted period</param>
        /// <returns><c>PeriodDto</c>: specific period if exist
        Task<BaseResult<PeriodDto>> GetByYearAndMonth(int userId, int year, int month);

        /// <summary>
        /// Get periods with pagination and ascending or descending sort
        /// </summary>
        /// <param name="currentPage">Start period</param>
        /// <param name="step">Count of periods</param>
        /// <param name="order">Order of collection</param>
        /// <returns><c>Collection of PeriodDto</c>: section of periods</returns>
        Task<CollectionResult<PeriodDto>> PeriodsPaging(int userId, int currentPage, int step, string order);
    }
}
