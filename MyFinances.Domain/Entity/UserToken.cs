using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// User JWT tokens
    /// </summary>
    public class UserToken: IEntityId<int>
    {
        public int Id { get; set; }

        public required string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
