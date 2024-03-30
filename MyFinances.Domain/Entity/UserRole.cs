namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// User role, with specific permissions
    /// </summary>
    public class UserRole
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}
