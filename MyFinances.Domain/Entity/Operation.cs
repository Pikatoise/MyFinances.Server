using MyFinances.Domain.Interfaces.Validations;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// Finance operation of user in certain period
    /// </summary>
    public class Operation: IEntityId<int>
    {
        public int Id { get; set; }

        public int PeriodId { get; set; }

        public Period Period { get; set; } = null!;

        public required string Title { get; set; }

        public double Amount { get; set; }
    }
}
