namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// Word which associated with type
    /// </summary>
    public class TypeAssociation
    {
        public required string Association { get; set; }

        public int TypeId { get; set; }

        public OperationType Type { get; set; } = null!;
    }
}
