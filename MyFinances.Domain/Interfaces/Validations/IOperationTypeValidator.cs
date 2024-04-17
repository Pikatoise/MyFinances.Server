using MyFinances.Domain.Entity;
using MyFinances.Domain.Result;

namespace MyFinances.Domain.Interfaces.Validations
{
    public interface IOperationTypeValidator: IBaseValidator<OperationType>
    {
        /// <summary>
        /// Check is type not null and association doesnt not exist yet
        /// </summary>
        /// <param name="operationType">Associated type</param>
        /// <param name="typeAssociation">New association</param>
        /// <returns><c>BaseResult</c>: empty BaseResult, if validation was successful
        /// <para><c>BaseResult with Error</c>: otherwise</para></returns>
        BaseResult AddTypeAssociationValidator(OperationType? operationType, TypeAssociation? typeAssociation);
    }
}
