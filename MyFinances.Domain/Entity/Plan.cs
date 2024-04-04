﻿using MyFinances.Domain.Interfaces;

namespace MyFinances.Domain.Entity
{
    /// <summary>
    /// A plan to make some financial operation in the future
    /// </summary>
    public class Plan: IEntityId<int>, IAuditable
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime FinalDate { get; set; }

        /// <summary>
        /// Represented in enum <c>PlanStatuses</c>
        /// </summary>
        public int Status { get; set; }

        public int TypeId { get; set; }

        public OperationType Type { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
