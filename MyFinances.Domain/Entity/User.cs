using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User: IEntityId<int>, IAuditable
    {
        public int Id { get; set; }

        public required string Login { get; set; }

        public required string Password { get; set; }

        public List<Period> Periods { get; set; } = [];

        public List<Plan> Plans { get; set; } = [];

        public List<Role> Roles { get; set; } = [];

        public UserToken UserToken { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
