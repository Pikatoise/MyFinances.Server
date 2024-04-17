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
        Task<CollectionResult<OperationTypeDto>> GetTypesByAssociation(string association);

        /// <summary>
        /// Get all available types of operation
        /// </summary>
        /// <returns><c>Collection of OperationTypeDto</c>: type with id and image source</returns>
        Task<CollectionResult<OperationTypeDto>> GetAllTypes();

        /// <summary>
        /// Add new association to operation type
        /// </summary>
        /// <param name="typeId">Associated type</param>
        /// <param name="association">New association</param>
        /// <returns>Type to which the association was added</returns>
        Task<BaseResult<OperationTypeDto>> AddTypeAssociation(int typeId, string association);
    }
}