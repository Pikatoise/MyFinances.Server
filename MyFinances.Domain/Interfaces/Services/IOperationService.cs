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
        /// <returns>
        /// Collection of sums
        /// </returns>
        Task<CollectionResult<int>> GroupByTypeAndSum(int periodId);

        /// <summary>
        /// Get all operations by period
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns>Collection of operations</returns>
        Task<CollectionResult<OperationDto>> GetOperationsByPeriod(int periodId);

        /// <summary>
        /// Delete operation by identificator
        /// </summary>
        /// <param name="operationId">Operation identificator</param>
        /// <returns>Deleted operation if success, null otherwise</returns>
        Task<BaseResult<OperationDto?>> DeleteOperationById(int operationId);

        /// <summary>
        /// Add operation
        /// </summary>
        /// <param name="dto">Data for new operation</param>
        /// <returns>Created operation if success, null otherwise</returns>
        Task<BaseResult<OperationDto?>> AddOperation(CreateOperationDto dto);

        /// <summary>
        /// Update operation
        /// </summary>
        /// <param name="dto">Data for operation update</param>
        /// <returns>Updated operation if success, null otherwise</returns>
        Task<BaseResult<OperationDto?>> UpdateOperation(UpdateOperationDto dto);
    }
}
