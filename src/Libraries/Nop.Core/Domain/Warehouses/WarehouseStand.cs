using System;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Localization;

namespace Nop.Core.Domain.Warehouses
{
    /// <summary>
    /// Represents a stand within a warehouse, this class is essential for managing the physical infrastructure used for storing and organizing products in a warehouse setting.
    /// </summary>
    public class WarehouseStand : BaseEntity, ISoftDeletedEntity, ILocalizedEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the warehouse where the stand is located.
        /// </summary>
        public int WarehouseId { get; set; }

        /// <summary>
        /// Gets or sets the type of material the stand is made from, impacting its durability and the types of items it can safely hold.
        /// </summary>
        public string MaterialType { get; set; }

        /// <summary>
        /// Gets or sets a brief description of the stand, which may include its purpose, or any other relevant details.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the number of shelves that the stand has, determining its capacity for storing items.
        /// </summary>
        public int NoOfShelves { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether the stand is currently active and available for use in the warehouse.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stand record was initially created, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the stand record was last updated, in Coordinated Universal Time (UTC).
        /// </summary>
        public DateTime UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who initially created the stand record.
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the user ID of the individual who last updated the stand record.
        /// </summary>
        public int UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the stand record has been marked as deleted from the system.
        /// </summary>
        public bool Deleted { get; set; }
    }
}
