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
        /// Group operations by type and get sums of groups
        /// <para><c>Method for diagrams</c></para>
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns><c>Collection of ints</c>: collection of sums </returns>
        Task<CollectionResult<int>> GroupByTypeAndSum(int periodId);

        /// <summary>
        /// Get all operations by period
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns><c>Collection of OperationDto</c>: collection of operations</returns>
        Task<CollectionResult<OperationDto>> GetOperationsByPeriod(int periodId);

        /// <summary>
        /// Filter operations by type
        /// </summary>
        /// <param name="operations">Operations to filter</param>
        /// <param name="typeFilterId">Identificator of type for filter</param>
        /// <returns><c>Collection of OperationDto</c>: filtered operations</returns>
        Task<CollectionResult<OperationDto>> FilterOperationsByType(IEnumerable<OperationDto> operations, int typeFilterId);

        /// <summary>
        /// Filter operations by profitability or unprofitability
        /// </summary>
        /// <param name="operations">Operations to filter</param>
        /// <param name="isProfit">profitability filter</param>
        /// <returns><c>Collection of OperationDto</c>: filtered operations</returns>
        Task<CollectionResult<OperationDto>> FilterOperationsByProfit(IEnumerable<OperationDto> operations, bool isProfit);

        /// <summary>
        /// Delete operation by identificator
        /// </summary>
        /// <param name="operationId">Operation identificator</param>
        /// <returns><c>OperationDto</c>: deleted operation if success
        /// <para><c>null</c>: otherwise</para></returns>
        Task<BaseResult<OperationDto?>> DeleteOperationById(int operationId);

        /// <summary>
        /// Add operation
        /// </summary>
        /// <param name="dto">Data for new operation</param>
        /// <returns><c>OperationDto</c>: created operation if success
        /// <para><c>null</c>: otherwise</para></returns>
        Task<BaseResult<OperationDto?>> CreateOperation(CreateOperationDto dto);

        /// <summary>
        /// Update operation
        /// </summary>
        /// <param name="dto">Data for operation update</param>
        /// <returns><c>OperationDto</c>: updated operation if success
        /// <para><c>null</c>: otherwise</para></returns>
        Task<BaseResult<OperationDto?>> UpdateOperation(UpdateOperationDto dto);
    }
}
