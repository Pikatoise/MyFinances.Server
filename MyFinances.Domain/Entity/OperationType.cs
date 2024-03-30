using MyFinances.Domain.Interfaces.Validations;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// Type of operations
    /// </summary>
    public class OperationType: IEntityId<int>, IAuditable
    {
        public int Id { get; set; }

        public required string Icon { get; set; }

        public List<TypeAssociation> Associations { get; set; } = [];

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
