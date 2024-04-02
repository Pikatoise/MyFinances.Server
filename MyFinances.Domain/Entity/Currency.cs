using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// Server stored currency
    /// </summary>
    public class Currency: IAuditable
    {
        public required string Name { get; set; }

        public required double Value { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

    }
}
