using MyFinances.Domain.DTO.Operation;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service responsible for user operation controle
    /// </summary>
    public interface IOperationService
    {
        /// <summary>
        /// Get all operations of period, which grouped by type
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns>
        /// Collection of groups with operations
        /// </returns>
        Task<CollectionResult<IEnumerable<OperationDto>>> GroupByType(int periodId);
    }
}
