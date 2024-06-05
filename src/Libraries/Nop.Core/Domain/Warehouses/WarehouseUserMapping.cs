using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Represents the association between users and warehouses, facilitating user-specific access and operations within designated warehouses.
    /// </summary>
    public class WarehouseUserMapping : BaseEntity, ISoftDeletedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the warehouse, establishing warehouse side of the mapping relationship.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the user, establishing the user side of the mapping relationship.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the user's association with the warehouse is currently active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the user is blocked from accessing warehouse functionalities.
        /// </summary>
        public bool IsBlocked { get; set; }

        /// <summary>
        /// Gets or sets the reason why the user is blocked, providing context for administrative actions.
        /// </summary>
        public string BlockReason { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was blocked, aiding in audit trails and potential review processes.
        /// </summary>
        public DateTime? BlockedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the mapping was initially created, in Coordinated Universal Time (UTC), providing a timestamp for the establishment of the relationship.
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the mapping was last updated, in Coordinated Universal Time (UTC), allowing for tracking of changes over time.
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the mapping, providing accountability and traceability for data entries.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the mapping, ensuring that modifications are traceable to specific users.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the mapping has been marked as deleted from the system, enabling soft deletion where the data is retained but marked as inactive.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
