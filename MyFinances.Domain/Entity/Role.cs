using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// User role with some permissions
    /// </summary>
    public class Role: IEntityId<int>
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public List<User> Users { get; set; } = [];
    }
}
