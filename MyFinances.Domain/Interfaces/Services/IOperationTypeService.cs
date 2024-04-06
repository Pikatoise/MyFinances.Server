using MyFinances.Domain.DTO.OperationType;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Services
{
    /// <summary>
    /// Service responsible for controle operation types and their associations
    /// </summary>
    public interface IOperationTypeService
    {
        /// <summary>
        /// Get operation type that fits under user association
        /// </summary>
        /// <param name="association">User input association</param>
        /// <returns><c>Collection of OperationTypeDto</c>: type with id and image source</returns>
        Task<CollectionResult<OperationTypeDto>> GetTypeByAssociation(string association);
    }
}
