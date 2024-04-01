using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// Finance operation of user in certain period
    /// </summary>
    public class Operation: IEntityId<int>, IAuditable
    {
        public int Id { get; set; }

        public int PeriodId { get; set; }

        public Period Period { get; set; } = null!;

        public required string Title { get; set; }

        public double Amount { get; set; }

        public int TypeId { get; set; }

        public OperationType Type { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
