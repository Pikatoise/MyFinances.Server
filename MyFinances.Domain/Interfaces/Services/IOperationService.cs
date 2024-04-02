using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service responsible for user operation controle
    /// </summary>
    public interface IOperationService
    {
        /// <summary>
        /// Group operations by type and get sums of groups
        /// <para><c>Method for diagrams</c></para>
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns>
        /// Collection of sums
        /// </returns>
        Task<CollectionResult<int>> GroupByTypeAndSum(int periodId);
    }
}
