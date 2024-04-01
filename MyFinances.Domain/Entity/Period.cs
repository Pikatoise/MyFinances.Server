using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// Period with operations in current month:year
    /// </summary>
    public class Period: IEntityId<int>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;

        public List<Operation> Operations { get; set; } = [];

        public int Month { get; set; }

        public int Year { get; set; }
    }
}
