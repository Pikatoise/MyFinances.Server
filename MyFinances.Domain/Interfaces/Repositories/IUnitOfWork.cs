using Microsoft.EntityFrameworkCore.Storage;
using MyFinances.Domain.Entity;

namespace MyFinances.Domain.Interfaces.Repositories
{
    /// <summary>
    /// The general context for repositories and database work
    /// </summary>
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<int> SaveChangesAsync();

        bool IsRun();

        IBaseRepository<User> Users { get; }

        IBaseRepository<UserRole> UserRoles { get; }

        IBaseRepository<UserToken> UserTokens { get; }

        IBaseRepository<Role> Roles { get; }

        IBaseRepository<TypeAssociation> TypeAssociations { get; }

        IBaseRepository<OperationType> OperationTypes { get; }

        IBaseRepository<Plan> Plans { get; }

        IBaseRepository<Period> Periods { get; }

        IBaseRepository<Operation> Operations { get; }
    }
}
