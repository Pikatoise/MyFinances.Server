using Microsoft.EntityFrameworkCore.Storage;
using MyFinances.Domain.Entity;
using MyFinances.Domain.Interfaces.Repositories;

namespace MyFinances.DAL.Repositories
{
    public class UnitOfWork(
        ApplicationDbContext context,
        IBaseRepository<Operation> operations,
        IBaseRepository<Period> periods,
        IBaseRepository<Plan> plans,
        IBaseRepository<OperationType> operationTypes,
        IBaseRepository<TypeAssociation> typeAssociations,
        IBaseRepository<Role> roles,
        IBaseRepository<UserToken> userTokens,
        IBaseRepository<UserRole> userRoles,
        IBaseRepository<User> users): IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public IBaseRepository<User> Users { get; } = users;
        public IBaseRepository<UserRole> UserRoles { get; } = userRoles;
        public IBaseRepository<UserToken> UserTokens { get; } = userTokens;
        public IBaseRepository<Role> Roles { get; } = roles;
        public IBaseRepository<TypeAssociation> TypeAssociations { get; } = typeAssociations;
        public IBaseRepository<OperationType> OperationTypes { get; } = operationTypes;
        public IBaseRepository<Plan> Plans { get; } = plans;
        public IBaseRepository<Period> Periods { get; } = periods;
        public IBaseRepository<Operation> Operations { get; } = operations;

        public bool IsRun() => _context.Database.CanConnectAsync().Result;

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
