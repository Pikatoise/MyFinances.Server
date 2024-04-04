﻿using MyFinances.Domain.DTO.Operation;
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
        /// <returns><c>IEnumerable of ints</c>: collection of sums </returns>
        Task<CollectionResult<int>> GroupByTypeAndSum(int periodId);

        /// <summary>
        /// Get all operations by period
        /// </summary>
        /// <param name="periodId">Period identificator</param>
        /// <returns><c>IEnumerable of OperationDto</c>: collection of operations</returns>
        Task<CollectionResult<OperationDto>> GetOperationsByPeriod(int periodId);

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
