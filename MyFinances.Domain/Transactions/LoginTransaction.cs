namespace MyFinances.Domain.Transactions
{
    public class LoginTransaction
    {
        public int UserId { get; set; }

        public string UserLogin { get; set; } = null!;
    }
}
