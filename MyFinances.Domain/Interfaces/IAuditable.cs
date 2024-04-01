namespace MyFinances.Domain.Interfaces
{
    /// <summary>
    /// Contract that track entity changes
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Last update date, null if never updated
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
