using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// Type of operations
    /// </summary>
    public class OperationType: IEntityId<int>, IAuditable
    {
        public int Id { get; set; }

        public required string IconSrc { get; set; }

        public List<Operation> Operations { get; set; } = [];

        public List<Plan> Plans { get; set; } = [];

        public List<TypeAssociation> Associations { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
