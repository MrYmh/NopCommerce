using System;
using Nop.Core.Domain.Common;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Links warehouse categories to specific warehouses.
    /// </summary>
    public class WarehouseCategoryMapping : BaseEntity, ISoftDeletedEntity
    {

        /// <summary>
        /// Gets or sets the unique identifier for the warehouse associated with this category mapping.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the warehouse category being applied to the warehouse.
        /// </summary>
        public int WarehouseCategoryId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether this mapping is a system-defined default (true) or a custom mapping (false).
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the mapping was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the mapping was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the category mapping.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the category mapping.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the category mapping has been marked as deleted, allowing for soft deletion where records are retained in the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
